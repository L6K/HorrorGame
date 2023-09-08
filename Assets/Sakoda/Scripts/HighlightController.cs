using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighlightController : MonoBehaviour
{
    public void IsHighlighting(RaycastHit objectTag)
    {

        Debug.Log(objectTag);
        //if(objectTag)
        //{
        //    gameObject.GetComponent<Outline>().enabled = true;
        //    if (gameObject.GetComponentInChildren<TextMeshPro>())
        //    {
        //        gameObject.GetComponentInChildren<TextMeshPro>().enabled = true;
        //    }
        //}
        //else
        //{
        //    Debug.Log(objectTag);
        //}
    }
}
