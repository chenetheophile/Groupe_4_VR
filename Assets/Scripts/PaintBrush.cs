using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Random = System.Random;

public class PaintBrush : MonoBehaviour
{
    [Range(0.05f, 3)] public float brushDepth = 0.05f;
    public LayerMask layers;
    [Range(0, 1)] public float brushWidth = 1;
    public Texture2D brushTexture;
    bool hasHitPaintable = false;
    XRGrabInteractable interactable;
    Vector3 original_position;
    Color lastColor;
    public bool hasBegin = false;
    public Color color_brush;
    Random generator;
    public int Score=3;


    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<XRGrabInteractable>();
        interactable.selectEntered.AddListener(OnSelect);
        interactable.selectExited.AddListener(OnSelectExit);
        original_position = transform.position;
        generator = new Random();

    }

    // Update is called once per frame
    void Update()
    {
        if (color_brush != lastColor)
        {
            lastColor = color_brush;
            GetComponentInChildren<Renderer>().material.color = color_brush;
        }
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, brushDepth, layers))
        {

            Vector2 hitUV = hit.textureCoord;
            PaintCanvas libre = hit.transform.GetComponent<PaintCanvas>();
            PaintCanvas_MJ MJ = hit.transform.GetComponent<PaintCanvas_MJ>();
            if(libre != null)
            {
                libre.Paint(hitUV, brushWidth, brushTexture);
                hasHitPaintable = true;
            }
            else if(MJ != null)
            { 
                if (hasBegin)
                {
                    Color colorHit = getPixelColor(hit.transform.GetComponent<PaintCanvas_MJ>().GetComponentInParent<Transform>(), hitUV.x, hitUV.y);
                    if (colorHit == Color.white || colorHit == color_brush) //Si la couleur est différente de blanc ou la couleur du pinceau,
                                                                            //c'est qu on a touché le bord
                    {
                        if ( brushWidth!=0.025f)
                        {
                            brushWidth = 0.025f;
                            Debug.Log("Partie Commencé");

                        }
                    }
                    else
                    {
                        Debug.Log("Partie Perdu");
                        majScore(Score);
                        FindObjectOfType<TP>().TP_Menu();
                        Score = 0;
                        brushWidth = 0;
                        hasBegin = false;
                        runGame();
                        return;
                    }
                }
                
                MJ.Paint(hitUV, brushWidth, brushTexture);
                hasHitPaintable = true;
            }

        }
        else
        {
            hasHitPaintable = false;
        }
    }

    public void majScore(int score)
    {
        foreach (TextMeshProUGUI tmp in FindObjectsOfType<TextMeshProUGUI>())
        {
            
            if (tmp.tag == "Score")
            {
                Debug.Log(tmp.tag);
                tmp.SetText("Score: "+score);
            }
        };
    }

    private void OnDestroy()
    {
        if (interactable != null)
            interactable.selectEntered.RemoveListener(OnSelect);
    }
    void OnSelect(SelectEnterEventArgs args)
    {
        Debug.Log("Pinceau changé");
    }
    void OnSelectExit(SelectExitEventArgs args)
    {
        transform.position = original_position;
    }
    /*private void OnDrawGizmos()
    {
        if (hasHitPaintable)
            Gizmos.color = Color.green;
        else
            Gizmos.color = Color.blue;
        if (hasHitPaintable)
            Gizmos.color = Color.green;
        else
            Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, transform.forward);
    }*/
    public Color getPixelColor(Transform obj, float x, float y)
    {
        Texture mainTexture = obj.GetComponent<Renderer>().material.mainTexture;
        RenderTexture currentRT = RenderTexture.active;
        Texture2D texture2D = new Texture2D(mainTexture.width, mainTexture.height, TextureFormat.RGBA32, false);
        RenderTexture renderTexture = new RenderTexture(mainTexture.width, mainTexture.height, 32);
        RenderTexture.active = renderTexture;
        Graphics.Blit(mainTexture, renderTexture);

        texture2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        texture2D.Apply();

        //Debug.Log((int)(x * mainTexture.width) + "," + (int)(y * mainTexture.height));
        Color pixels = texture2D.GetPixel((int)(x * mainTexture.width), (int)(y * mainTexture.height));
        RenderTexture.active = currentRT;
        return pixels;
    }
    List<Collider> getLabyColliders()
    {
        List<Collider> all_collider = new List<Collider>();
        foreach (MG_Logic logique in FindObjectsOfType<MG_Logic>(true).ToList())
        {
            all_collider.Add(logique.transform.GetComponent<Collider>());
        }
        
        all_collider = all_collider.OrderBy(o => o.name).ToList();
        Debug.Log("Collider: "+all_collider.Count);
        return all_collider;
    }
    void activeLaby(int number)
    {
        List<Collider> laby_colliders = getLabyColliders();
        for (int i = 0; i < laby_colliders.Count; i++)
        {
            if (i == number * 2 || i == number * 2 + 1)
            {
                laby_colliders[i].transform.gameObject.SetActive(true);
            }
                
            else
                laby_colliders[i].transform.gameObject.SetActive(false);
        }
    }
    public void runGame()
    {
        PaintCanvas_MJ MJ = FindObjectOfType<PaintCanvas_MJ>();
        int number = generator.Next(0, 3);
        MJ.drawLabyrinth(number);
        activeLaby(number);
    }
}