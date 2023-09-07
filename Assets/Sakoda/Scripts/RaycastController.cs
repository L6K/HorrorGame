using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RaycastController : MonoBehaviour
{

    RaycastManager raycastManager;
    private Animator _doorAnimator;
    private bool _isHidable;


    private void Start()
    {
        raycastManager = new RaycastManager();
    }

    /*
     * <summary>
     * コライダーにplayerが入ったら、Rayを飛ばす
     * </summary>
     */
    private void OnTriggerStay(Collider other)
    {
        RaycastHit _hitObject = raycastManager.GetRaycastHitInfo();
        if (_hitObject.collider != null && other.CompareTag("Room"))
        {
            string _objectTag = _hitObject.collider.tag;
            Outline _outline = other.GetComponentInChildren<Outline>();
            TextMeshPro _textMeshPro = other.GetComponentInChildren<TextMeshPro>();
            _doorAnimator = other.GetComponentInChildren<Animator>();

            switch (_objectTag)
            {
                case "Item":
                    _hitObject.collider.GetComponent<Outline>().enabled = true;

                    break;

                case "Locker":
                    _hitObject.collider.GetComponent<Outline>().enabled = true;
                    _hitObject.collider.GetComponentInChildren<TextMeshPro>().enabled = true;
                    _isHidable = true;

                    break;

                case "Stair":
                    break;

                default:
                    if (_outline != null)
                    {
                        _outline.enabled = false;
                    }

                    if (_textMeshPro != null)
                    {
                        _textMeshPro.enabled = false;
                        //_doorAnimator.enabled = false;
                    }

                    break;
            }

            if (_isHidable)
            {
                GetComponent<HideController>().IsHiding(_isHidable);
            }
        }
    }
}