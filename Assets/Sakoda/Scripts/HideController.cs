using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HideController : MonoBehaviour
{
    private Animator _doorAnimator;
    private AnimatorStateInfo _stateInfo;

    private bool _isHiding;
    private float _distanceToMove = 1f;

    private void Update()
    {
        
    }

    /*
     * <summary>
     * HighlightManagerからの呼び出しを受け特定の条件下で
     * 隠れる隠れないの動きを行う
     * </summary>
     */
    public bool IsHiding(bool _isHidable, RaycastHit hitObject)
    {
        _doorAnimator = hitObject.collider.GetComponent<Animator>();
        GameObject _locker = hitObject.transform.parent.gameObject;
        FirstPersonController playerController = GetComponent<FirstPersonController>();

        if (Input.GetKeyDown(KeyCode.F))
        {
            //ロッカーとの距離で隠れるか外に出るかの判定を行う
            if (_isHiding)
            {

                //プレイヤーの位置をロッカーから指定した距離分前の位置に移す
                transform.position = transform.position + transform.forward * _distanceToMove;
                hitObject.collider.GetComponentInChildren<TextMeshPro>().text = "F:Hide";

                playerController.enableHeadBob = true;
                playerController.playerCanMove = true;

                _isHiding = false;
                _isHidable = false;
            }
            else
            {
                Vector3 _hidingPosition = _locker.transform.position;
                transform.position = _hidingPosition;
                transform.rotation = Quaternion.Euler(0, 180f, 0);

                playerController.enableHeadBob = false;
                playerController.playerCanMove = false;

                hitObject.collider.GetComponentInChildren<TextMeshPro>().text = "F:Out";

                _isHiding = true;
            }
        }
        return _isHidable;
    }
}