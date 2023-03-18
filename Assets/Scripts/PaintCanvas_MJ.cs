using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PaintCanvas_MJ : MonoBehaviour
{
    private List<Texture2D> textureList=new List<Texture2D>();
    public Texture2D[] textureArray;
    public RenderTexture paintableAreaRT;
    public int textureResolution = 256;


    void Start()
    {
        string baseFileName = "Assets/Image/laby/";
        for (int i = 1; i < 5; i++)
        {
            textureList.Add((Texture2D)AssetDatabase.LoadAssetAtPath(baseFileName + i + ".png", typeof(Texture2D)));

        }
        foreach(Texture2D texture in textureList)
        {
            Debug.Log(texture.name);
        }
    }
    public void Paint(Vector2 uv, float brushWidth, Texture2D brushTex)
    {
        
        //Activate RT
        RenderTexture.active = paintableAreaRT;
        // save matrixes
        GL.PushMatrix();
        // setup matrix for correct size
        GL.LoadPixelMatrix(0, textureResolution, textureResolution, 0);

        //Setup UVs to be the right scale
        uv.x *= textureResolution;
        uv.y = textureResolution * (1 - uv.y);

        //Scale the brush witdh to match the scale of the object in the world and the res of the texture
        brushWidth *= textureResolution;

        //Paint on RT
        Rect paintRect = new Rect(uv.x - brushWidth * 0.5f, uv.y - brushWidth * 0.5f, brushWidth, brushWidth);
        Color color=FindObjectOfType<ColorPickerTriangle>().TheColor;
        Graphics.DrawTexture(paintRect, brushTex, new Rect(0, 0, 1, 1), 0, 0, 0, 0, color, null);

        GL.PopMatrix();
        // turn off RT
        RenderTexture.active = null;
    }

    public void ClearOutRenderTexture(RenderTexture renderTexture)
    {
        RenderTexture.active = renderTexture;
        GL.Clear(true, true, new Color(0, 0,0 ,0));
        RenderTexture.active = null;
    }
    public void drawLabyrinth(int lab)
    {
        Debug.Log("Lab n°"+lab);
        if (textureArray.Length > 0)
        {
            Debug.Log("Labyrinthe changé");
            Graphics.Blit(textureArray[lab], paintableAreaRT);
        }
    }
}
