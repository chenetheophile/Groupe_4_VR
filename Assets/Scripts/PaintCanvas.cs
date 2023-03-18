using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintCanvas : MonoBehaviour
{
    public int textureResolution = 256;
    public RenderTexture paintableAreaRT;

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
        GL.Clear(true, true, new Color(1, 1, 1, 0));
        RenderTexture.active = null;
    }

}
