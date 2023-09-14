using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class HighlightController : MonoBehaviour
{

    RaycastManager raycastManager;
    RaycastHit _hitObject;

    private string _objectTag;

    public bool _canAct;
    public bool _isHiding;

    HashSet<TextMeshPro> textMeshPros = new HashSet<TextMeshPro>();


    private void Start()
    {
        raycastManager = new RaycastManager();
    }

    private void Update()
    {
        textMeshPros.RemoveWhere(o => o == null);
        _hitObject = raycastManager.GetRaycastHitInfo();

        if (_hitObject.collider != null)
        {
            _objectTag = _hitObject.collider.tag;

            switch (_objectTag)
            {
                case "Item":

                    TextMeshPro _textMeshPro = _hitObject.collider.GetComponentInChildren<TextMeshPro>();
                    _textMeshPro.enabled = true;
                    textMeshPros.Add(_textMeshPro);
                    _canAct = true;
                    break;

                case "Locker":

                    _textMeshPro = _hitObject.collider.GetComponentInChildren<TextMeshPro>();
                    _textMeshPro.enabled = true;
                    textMeshPros.Add(_textMeshPro);
                    _canAct = true;
                    //_doorAnimator = _hitObject.collider.GetComponent<Animator>();

                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        if (_canAct && !_isHiding)
                        {
                            GetComponent<HideController>().IsHide(_hitObject);
                        }
                        else if (_isHiding)
                        {
                            GetComponent<HideController>().IsOut(_hitObject);
                        }
                    }
                    break;

                default:

                    foreach (var t in textMeshPros)
                    {
                        if (t != null)
                        {
                            t.enabled = false;
                        }
                    }

                    _canAct = false;
                    break;
            }
        }
    }
}

