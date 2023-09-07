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
     * �e�I�u�W�F�N�g�����R���C�_�[��player����������A�������s��
     * </summary>
     */
    private void OnTriggerStay(Collider other)
    {
        RaycastHit _hitObject = raycastManager.GetRaycastHitInfo();

        if (_hitObject.collider != null)
        {
            string _objectTag = _hitObject.collider.tag;
            Outline _outline = _hitObject.collider.GetComponent<Outline>();
            TextMeshPro _textMeshPro = _hitObject.collider.GetComponentInChildren<TextMeshPro>();
            _doorAnimator = other.GetComponentInChildren<Animator>();

            switch (_objectTag)
            {
                case "Item":
                    _outline.enabled = true;

                    break;

                case "Locker":
                    Debug.Log(_outline);
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
     * player���Ώۂ�object���痣�ꂽ�Ƃ��ɏ������s��
     * </summary>
     */
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Stair"))
        {
            Outline _outline = other.GetComponentInChildren<Outline>();
            TextMeshPro _textMeshPro = other.GetComponentInChildren<TextMeshPro>();
            if (_textMeshPro || _outline)
            {
                _outline.enabled = false;
                _textMeshPro.enabled = false;
            }
        }
    }
}

