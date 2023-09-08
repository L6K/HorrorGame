using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighlightController : MonoBehaviour
{

    RaycastManager raycastManager;
    private Animator _doorAnimator;
    private bool _isHidable;

    HashSet<Outline> outlines = new HashSet<Outline>();
    HashSet<TextMeshPro> textMeshPros = new HashSet<TextMeshPro>();


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
        RaycastHit _hitObject;
        string _objectTag;

        if (other.CompareTag("Room"))
        {
            outlines.RemoveWhere(o => o == null);
            textMeshPros.RemoveWhere(o => o == null);

            _hitObject = raycastManager.GetRaycastHitInfo();

            if(_hitObject.collider != null)
            {
                _objectTag = _hitObject.collider.tag;

                switch (_objectTag)
                {
                    case "Item":
                        Outline _outline = _hitObject.collider.GetComponent<Outline>();
                        TextMeshPro _textMeshPro = _hitObject.collider.GetComponentInChildren<TextMeshPro>();
                        _outline.enabled = true;
                        _textMeshPro.enabled = true;

                        outlines.Add(_outline);
                        textMeshPros.Add(_textMeshPro);

                        break;

                    case "Locker":
                        _outline = _hitObject.collider.GetComponent<Outline>();
                        _textMeshPro = _hitObject.collider.GetComponentInChildren<TextMeshPro>();
                        _outline.enabled = true;
                        _textMeshPro.enabled = true;

                        _isHidable = true;

                        outlines.Add(_outline);
                        textMeshPros.Add(_textMeshPro);

                        if (_isHidable)
                        {
                            GetComponent<HideController>().IsHiding(_isHidable, _hitObject);
                        }

                        break;

                    case "Stair":
                        break;

                    default:
                        foreach (var o in outlines)
                        {
                            foreach (var t in textMeshPros)
                            {
                                if (o != null && t != null)
                                {
                                    o.enabled = false;
                                    t.enabled = false;
                                }
                            }
                        }

                        break;
                }
            }
            
        }
    }

}

