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
    public Animator _doorAnimator;
    private bool _hasStateEnded;

    private float _canActingDistancce = 3.0f;
    private float _distanceToItem;
    private string _objectTag;

    private bool _isHidable;
    public bool _isHiding;

    HashSet<Outline> outlines = new HashSet<Outline>();
    HashSet<TextMeshPro> textMeshPros = new HashSet<TextMeshPro>();


    private void Start()
    {
        raycastManager = new RaycastManager();
    }

    private void Update()
    {
        outlines.RemoveWhere(o => o == null);
        textMeshPros.RemoveWhere(o => o == null);

        _hitObject = raycastManager.GetRaycastHitInfo();

        if (_hitObject.collider != null)
        {
            _objectTag = _hitObject.collider.tag;
            _distanceToItem = Vector3.Distance(transform.position, _hitObject.transform.position);

            _isHidable = _distanceToItem <= _canActingDistancce;

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

                    _doorAnimator = _hitObject.collider.GetComponent<Animator>();

                    outlines.Add(_outline);
                    textMeshPros.Add(_textMeshPro);

                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        if (_isHidable && !_isHiding)
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

                    _doorAnimator.SetBool("Open", false);
                    break;
            }
        }
        else
        {
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
        }
    }

    //private IEnumerator WaitForAnimationEnd()
    //{
    //    AnimatorStateInfo stateInfo = _doorAnimator.GetCurrentAnimatorStateInfo(0);

    //    while (true)
    //    {
    //        // アニメーションステートが終了したらループを抜ける
    //        if(stateInfo.IsName("Open") && stateInfo.normalizedTime >= 1f)
    //        {
    //            Debug.Log("finish");
    //            break;
    //        }

    //        yield return null;
    //    }

    //    Debug.Log("Finish");

    //    // アニメーションステートが終了した後の処理
    //    //if (!_isHiding)
    //    //{
    //    //    GetComponent<HideController>().IsHide(_hitObject);
    //    //}
    //    //else if (_isHiding)
    //    //{
    //    //    GetComponent<HideController>().IsOut(_hitObject);
    //    //}
    //}
}

