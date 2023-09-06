using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HideController : MonoBehaviour
{
    public GameObject locker;
    public GameObject player;
    private Animator animator;

    private bool _isHiding;
    private Vector3 _originalPosition;
    private float _distanceToMove = 1.0f;
    public float _distancePosition = 0.5f;

    /*
     * <summary>
     * HighlightManagerからの呼び出しを受け特定の条件下で
     * 隠れる隠れないの動きを行う
     * </summary>
     */
    public bool IsHiding(bool _isHidable)
    {
        //プレイヤーとロッカーの距離を計算
        float _distance = Vector3.Distance(player.transform.position, locker.transform.position);

        _isHiding = player.transform.position == locker.transform.position;
        animator = locker.GetComponentInChildren<Animator>();

        if (Input.GetKeyDown(KeyCode.F))
        {
            //ロッカーとの距離で隠れるか外に出るかの判定を行う
            if (_distance <= _distancePosition)
            {
                //プレイヤーの位置をロッカーから指定した距離分前の位置に移す
                player.transform.position = locker.transform.position + locker.transform.forward * _distanceToMove;
                Debug.Log(player.transform.position);
                player.GetComponent<FirstPersonController>().playerCanMove = true;
                _isHidable = false;
            }
            else
            {
                //animator.enabled = true;
                Vector3 _hidingPosition = locker.transform.position;
                player.transform.position = _hidingPosition;
                player.transform.rotation = Quaternion.Euler(0, 180f, 0);
                player.GetComponent<FirstPersonController>().playerCanMove = false;
                locker.GetComponentInChildren<TextMeshPro>().text = "F:Out";
                Debug.Log(player.transform.position);
            }
        }

        return _isHidable;
    }
}

//animator = locker.GetComponentInChildren<Animator>();
//_originalPosition = locker.transform.position;

//if (Input.GetKeyDown(KeyCode.F))
//{
//    Debug.Log("f");
//    if (_isHiding)
//    {
//        transform.position = _originalPosition;
//        animator.enabled = true;
//    }
//    else
//    {
//        animator.enabled = true;
//        Vector3 _hidingPosition = locker.transform.position;
//        transform.position = _hidingPosition;
//        transform.rotation = Quaternion.Euler(0, 180f, 0);
//    }
//}

//return false;
