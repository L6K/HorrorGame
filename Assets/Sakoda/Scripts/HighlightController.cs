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
    private Animator _doorAnimator;
    private bool _hasStateEnded;

    private float _canActingDistancce = 3.0f;
    private float _distanceToItem;
    private string _objectTag;

    private bool _canAct;
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
            _distanceToItem = Vector3.Distance(transform.position, _hitObject.transform.position);

            _canAct = _distanceToItem <= _canActingDistancce;

            switch (_objectTag)
            {
                case "Item":

                    TextMeshPro _textMeshPro = _hitObject.collider.GetComponentInChildren<TextMeshPro>();
                    _textMeshPro.enabled = true;
                    textMeshPros.Add(_textMeshPro);

                    //if (_canAct && !_isHiding)
                    //{
                    //    GetComponent<ItemHandle>().InvestigateItem(_hitObject);
                    //}
                    break;

                case "Locker":

                    _textMeshPro = _hitObject.collider.GetComponentInChildren<TextMeshPro>();
                    _textMeshPro.enabled = true;
                    textMeshPros.Add(_textMeshPro);
                    _doorAnimator = _hitObject.collider.GetComponent<Animator>();

                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        if (_canAct && !_isHiding)
                        {
                            _doorAnimator.SetBool("Open", true);
                            StartCoroutine("WaitForAnimationEnd");
                            //GetComponent<HideController>().IsHide(_hitObject);
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

                    if (_doorAnimator != null)
                    {
                        _doorAnimator.SetBool("Open", false);
                        _doorAnimator.SetBool("Close", false);
                    }
                    break;
            }
        }
    }

    private IEnumerator WaitForAnimationEnd()
    {

        AnimatorStateInfo stateInfo = _doorAnimator.GetCurrentAnimatorStateInfo(0);
        yield return stateInfo.IsName("Open") && stateInfo.normalizedTime >= 1f;
        Debug.Log("finish");

        //while (true)
        //{
        //    アニメーションステートが終了したらループを抜ける
        //    if (stateInfo.IsName("Open") && stateInfo.normalizedTime >= 1f)
        //    {
        //        Debug.Log("finish");
        //        break;
        //    }

        //    yield return null;
        //}

        Debug.Log("Finish");

        // アニメーションステートが終了した後の処理
        //if (!_isHiding)
        //{
        //    GetComponent<HideController>().IsHide(_hitObject);
        //}
        //else if (_isHiding)
        //{
        //    GetComponent<HideController>().IsOut(_hitObject);
        //}
    }
}

