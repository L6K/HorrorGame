using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighlightManager : MonoBehaviour
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
     * 各オブジェクトが持つコライダーにplayerが入ったら、処理を行う
     * </summary>
     */
    private void OnTriggerStay(Collider other)
    {
        RaycastHit _hitObject = raycastManager.GetRaycastHitInfo();

        if (_hitObject.collider != null)
        {
            string _objectTag = _hitObject.collider.tag;
            Outline _outline = other.GetComponentInChildren<Outline>();
            TextMeshPro _textMeshPro = other.GetComponentInChildren<TextMeshPro>();
            _doorAnimator = other.GetComponentInChildren<Animator>();

            switch (_objectTag)
            {
                case "Item":
                    _outline.enabled = true;

                    break;

                case "Locker":
                    _outline.enabled = true;
                    _textMeshPro.enabled = true;
                    _isHidable = true;

                    break;

                case "Stair":
                    break;

                default:
                    if(_outline != null)
                    {
                        _outline.enabled = false;
                    }
                    
                    if(_textMeshPro != null)
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

    /*
     * <summary>
     * playerが対象のobjectから離れたときに処理を行う
     * </summary>
     */
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Stair"))
        {
            other.GetComponentInChildren<Outline>().enabled = false;
            TextMeshPro _textMeshPro = other.GetComponentInChildren<TextMeshPro>();
            if (_textMeshPro)
            {
                _textMeshPro.enabled = false;
            }
        }
    }
}

