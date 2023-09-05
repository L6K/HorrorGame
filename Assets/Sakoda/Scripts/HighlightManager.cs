using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighlightManager : MonoBehaviour
{

    RaycastManager raycastManager;

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
            Outline _outline = other.GetComponentInChildren<Outline>();
            TextMeshPro _textMeshPro = other.GetComponentInChildren<TextMeshPro>();

            switch (_objectTag)
            {
                case "Item":
                    _outline.enabled = true;
                    break;

                case "Locker":
                    _outline.enabled = true;
                    _textMeshPro.enabled = true;
                    break;

                default:
                    _outline.enabled = false;
                    if(_textMeshPro != null)
                    {
                        _textMeshPro.enabled = false;
                    }
                    break;
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
        other.GetComponentInChildren<Outline>().enabled = false;
        TextMeshPro _textMeshPro = other.GetComponentInChildren<TextMeshPro>();
        if (_textMeshPro)
        {
            _textMeshPro.enabled = false;
        }
    }
}