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

    private bool _canAct;
    private float _actDistance = 3.0f;
    public bool _isHiding;

    TextMeshPro _textMeshPro;
    Outline _outline;
    HashSet<TextMeshPro> textMeshPros = new HashSet<TextMeshPro>();
    HashSet<Outline> outlines = new HashSet<Outline>();


    private void Start()
    {
        raycastManager = new RaycastManager();
    }

    /// <summary>
    /// Updateで常にRayを発し、3ｆ以内にあるオブジェクトが何か判定するためのメソッド
    /// ItemとLockerが現在判定要素となっている
    /// </summary>
    private void Update()
    {
        textMeshPros.RemoveWhere(o => o == null);
        outlines.RemoveWhere(o => o == null);
        _hitObject = raycastManager.GetRaycastHitInfo();

        if (_hitObject.collider != null)
        {
            _objectTag = _hitObject.collider.tag;
            float _distance = Vector3.Distance(transform.position, _hitObject.transform.position);
            _canAct = _distance <= _actDistance;

            switch (_objectTag)
            {
                case "Item":

                    _outline = _hitObject.collider.GetComponentInChildren<Outline>();
                    _outline.enabled = true;
                    outlines.Add(_outline);
                    if (_outline)
                    {
                        _canAct = true;
                    }
                    
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        if (_canAct)
                        {
                            GetComponent<ItemHandle>().InvestigateItem(_hitObject);
                        }
                    }
                    break;

                case "Locker":

                    _textMeshPro = _hitObject.collider.GetComponentInChildren<TextMeshPro>();
                    _textMeshPro.enabled = true;
                    textMeshPros.Add(_textMeshPro);
                    _canAct = true;

                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        if (_canAct && !_isHiding)
                        {
                            _hitObject.collider.GetComponent<HideController>().SetRaycastHit(_hitObject);
                            _hitObject.collider.GetComponent<Animator>().SetBool("Hide", true);
                            //GetComponent<HideController>().IsHide(_hitObject);
                        }
                        else if (_isHiding)
                        {
                            _hitObject.collider.GetComponent<HideController>().SetRaycastHit(_hitObject);
                            _hitObject.collider.GetComponent<Animator>().SetBool("Out", true);
                            //GetComponent<HideController>().IsOut(_hitObject);
                        }
                    }
                    break;

                case "Piano":

                    _outline = _hitObject.collider.GetComponentInChildren<Outline>();
                    _outline.enabled = true;
                    outlines.Add(_outline);

                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        _hitObject.collider.GetComponent<Piano>().ReceiveAciton();
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

                    foreach (var o in outlines)
                    {
                        if (o != null)
                        {
                            o.enabled = false;
                        }
                    }

                    _canAct = false;
                    break;
            }
        }
    }
}

