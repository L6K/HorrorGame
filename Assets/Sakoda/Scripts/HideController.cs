//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;

//public class HideController : MonoBehaviour
//{
//    RaycastManager raycastManager;
//    public GameObject player;

//    private void Start()
//    {
//        raycastManager = new RaycastManager();
//    }

//    private void OnTriggerStay(Collider other)
//    {

//        if (other.CompareTag("LockerCollider"))
//        {
//            Outline _outline = other.GetComponentInChildren<Outline>();
//            bool _isTextPop = other.GetComponentInChildren<TextMeshPro>();

//            RaycastHit _hitObject = raycastManager.GetRaycastHitInfo();

//            if (_hitObject.collider.CompareTag("Locker"))
//            {
//                _outline.enabled = true;
//                _hitObject.collider.GetComponentInChildren<TextMeshPro>().enabled = true;
//            }
//            else
//            {
//                _outline.enabled = false;
//                _isTextPop = false;
//            }

//            if (_isTextPop)
//            {
//                player.GetComponent<FirstPersonController>().playerCanMove = false;
//            }
//        }
//    }
//}
