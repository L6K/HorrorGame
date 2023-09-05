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
     * playerが対象のobjectから離れたときに処理を行う
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