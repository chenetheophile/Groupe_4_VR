using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PaintBall : MonoBehaviour
{
    [Range(0.05f, 3)] public float brushDepth = 1;
    public LayerMask layers;
    [Range(0, 1)] public float brushWidth = 1;
    public Texture2D brushTexture;
    public Color color;
    Color lastColor;
    public Vector3 original_position;

    private void Start()
    {
        original_position = transform.position;
        Debug.Log(original_position);
        gameObject.SetActive(false);
    }
    void Update()
    {
        if(color != lastColor)
        {
            GetComponentInChildren<Renderer>().material.color = color;
            lastColor = color;
        }
            
    }
    void OnCollisionEnter(Collision other)
    {
        Debug.Log(gameObject.name + " collided with " + other.collider.name);
        PaintCanvas paint = other.collider.GetComponentInChildren<PaintCanvas>();
        if ( paint!= null)
        {
            RaycastHit hit = new RaycastHit();
            Ray hitUV = new Ray(transform.position, other.contacts[0].point-transform.position);
            if (Physics.Raycast(hitUV, out hit))
            {
                paint.Paint(hit.textureCoord, brushWidth, brushTexture);
            }
            
        }
    }
    public void resetPos()
    {
        GetComponent<Transform>().position = original_position;
        GetComponent<Rigidbody>().velocity=new Vector3(0, 0, 0);    
    }
}
