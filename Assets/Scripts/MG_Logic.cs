using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class MG_Logic : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        PaintBrush paint=other.GetComponent<PaintBrush>();
        if (gameObject.tag == "Depart")
        {
            Debug.Log("Collider Debut touché");
            paint.hasBegin=true;
        }else if(gameObject.tag == "Arrive")
        {
            Debug.Log("Collider Fin touché");
            paint.Score++;
            paint.hasBegin = false;
            paint.runGame();
        }
    }
}
