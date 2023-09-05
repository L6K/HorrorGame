using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHighlighter : MonoBehaviour
{

    RaycastManager raycastManager;

    private void Start()
    {
        raycastManager = new RaycastManager();
    }

    /*
     * <summary>
     * 各オブジェクトが持つコライダーにplayerが入ったら、処理を行う
     * </summary>
     */
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("HighlightCollider"))
        {
            RaycastHit _hitObject = raycastManager.GetRaycastHitInfo();
            string objectTag = _hitObject.collider.tag;

            //switch (objectTag)
            //{
            //    //case "Item":

            //}
        }
    }

    /*
     * <summary>
     * playerが対象のobjectから離れたときに処理を行う
     * </summary>
     */
    private void OnTriggerExit(Collider other)
    {
            other.GetComponentInChildren<Outline>().enabled = false;   
    }
}


//if (other.CompareTag("ItemCollider"))
//{
//    Outline outline = other.GetComponentInChildren<Outline>();
//    RaycastHit _hitObject = raycastManager.GetRaycastHitInfo();

//    if (_hitObject.collider.CompareTag("Item"))
//    {
//        outline.enabled = true;
//    }
//    else
//    {
//        outline.enabled = false;
//    }
//}