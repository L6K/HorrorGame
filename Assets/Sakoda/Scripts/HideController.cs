using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HideController : MonoBehaviour
{
    private Animator _doorAnimator;
    private AnimatorStateInfo _stateInfo;
    private FirstPersonController playerController;

    private float _distanceToMove = 1f;

    private void Start()
    {
        playerController = GetComponent<FirstPersonController>();
    }

    /*
     * <summary>
     * HighlightManagerからの呼び出しを受け特定の条件下で
     * 隠れる隠れないの動きを行う
     * </summary>
     */
    public void IsHiding(RaycastHit hitObject)
    {
        _doorAnimator = hitObject.collider.GetComponent<Animator>();
        GameObject _locker = hitObject.transform.parent.gameObject;

        if (Input.GetKeyDown(KeyCode.F))
        {
            Vector3 _hidingPosition = _locker.transform.position;
            transform.position = _hidingPosition;
            transform.rotation = Quaternion.Euler(0, 180f, 0);

            playerController.enableHeadBob = false;
            playerController.playerCanMove = false;

            hitObject.collider.GetComponentInChildren<TextMeshPro>().text = "F:Out";
            gameObject.GetComponent<HighlightController>()._isHiding = true;
        }
    }

    public void IsOuting(RaycastHit hitObject)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            //プレイヤーの位置をロッカーから指定した距離分前の位置に移す
            transform.position = transform.position + transform.forward * _distanceToMove;
            hitObject.collider.GetComponentInChildren<TextMeshPro>().text = "F:Hide";

            playerController.enableHeadBob = true;
            playerController.playerCanMove = true;

            gameObject.GetComponent<HighlightController>()._isHiding = false;
        }
    }
}