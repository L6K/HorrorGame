using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighlightController : MonoBehaviour
{

    RaycastManager raycastManager;
    RaycastHit _hitObject;
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

                    outlines.Add(_outline);
                    textMeshPros.Add(_textMeshPro);

                    if (_isHidable && !_isHiding)
                    {
                        GetComponent<HideController>().IsHiding(_hitObject);
                    }
                    else if (_isHiding)
                    {
                        GetComponent<HideController>().IsOuting(_hitObject);
                    }

                    Debug.Log(_isHiding);

                    break;

                default:
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

    /*
     * <summary>
     * コライダーにplayerが入ったら、Rayを飛ばし
     * Rayが当たったアイテムに対して、特定の行動を起こさせる
     * </summary>
     */
    //private void OnTriggerStay(Collider other)
    //{

    //    if (other.CompareTag("Room"))
    //    {
    //        //outlines.RemoveWhere(o => o == null);
    //        //textMeshPros.RemoveWhere(o => o == null);

    //        //_hitObject = raycastManager.GetRaycastHitInfo();

    //        //if(_hitObject.collider != null)
    //        //{
    //        //    _objectTag = _hitObject.collider.tag;

    //        //    _isHidable = _distanceToItem <= _canActingDistancce;

    //        //    switch (_objectTag)
    //        //    {
    //        //        case "Item":
    //        //            Outline _outline = _hitObject.collider.GetComponent<Outline>();
    //        //            TextMeshPro _textMeshPro = _hitObject.collider.GetComponentInChildren<TextMeshPro>();
    //        //            _outline.enabled = true;
    //        //            _textMeshPro.enabled = true;

    //        //            outlines.Add(_outline);
    //        //            textMeshPros.Add(_textMeshPro);

    //        //            break;

    //        //        case "Locker":
    //        //            _outline = _hitObject.collider.GetComponent<Outline>();
    //        //            _textMeshPro = _hitObject.collider.GetComponentInChildren<TextMeshPro>();
    //        //            _outline.enabled = true;
    //        //            _textMeshPro.enabled = true;

    //        //            outlines.Add(_outline);
    //        //            textMeshPros.Add(_textMeshPro);

    //        //            //if (_isHidable && !_isHiding)
    //        //            //{
    //        //            //    GetComponent<HideController>().IsHiding(_hitObject);
    //        //            //}
    //        //            //else if(_isHiding)
    //        //            //{
    //        //            //    GetComponent<HideController>().IsOuting(_hitObject);
    //        //            //}

    //        //            Debug.Log(_isHiding);

    //        //            break;

    //        //        default:
    //        //            break;
    //        //    }
    //        //}
    //        //else
    //        //{
    //        //    foreach (var o in outlines)
    //        //    {
    //        //        foreach (var t in textMeshPros)
    //        //        {
    //        //            if (o != null && t != null)
    //        //            {
    //        //                o.enabled = false;
    //        //                t.enabled = false;
    //        //            }
    //        //        }
    //        //    }
    //        //}
            
    //    }
    //}

}

