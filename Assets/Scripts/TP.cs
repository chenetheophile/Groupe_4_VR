using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TP : MonoBehaviour
{
    Vector3 originMJ = new Vector3(-8.5f, 1.8f, 1.5f);
    Vector3 originLibre = new Vector3(8.5f, 1.8f, 1.5f);
    Vector3 origin = new Vector3(0, 5, 15);
    Vector3 originPalettePos;
    Quaternion originPaletteRot;
    Vector3 originalPaletteScale;
    Transform colorPalette;
    void Start()
    {
        FindObjectOfType<PaintBrush>().majScore(0);
        colorPalette= FindObjectOfType<ColorPickerTriangle>().transform;
        originPaletteRot=colorPalette.localRotation;
        originPalettePos=colorPalette.localPosition;
        originalPaletteScale=colorPalette.localScale;
    }
    public void TP_Libre()
    {
        GetComponent<Transform>().position = originLibre;
        foreach(XRRayInteractor xRRayInteractor in FindObjectsOfType<XRRayInteractor>())
        {
            if (xRRayInteractor.tag == "MainGauche")
            {
                colorPalette.position = xRRayInteractor.transform.position;
                colorPalette.position += new Vector3(0, 0, -0.25f);
                colorPalette.rotation = Quaternion.Euler(new Vector3());
                colorPalette.rotation *= Quaternion.Euler(new Vector3(0,1,0) * -90);
                colorPalette.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            }
        }
        

    }
    public void TP_MJ()
    {
        GetComponent<Transform>().position = originMJ;
        FindObjectOfType<PaintBrush>().runGame();
    }
    public void TP_Menu()
    {
        GetComponent<Transform>().position = origin;
        colorPalette.position = originPalettePos-new Vector3(-7.5f,0,0);
        colorPalette.rotation = originPaletteRot;
        colorPalette.localScale = originalPaletteScale;

    }
}
