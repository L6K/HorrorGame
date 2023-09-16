using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HideController : MonoBehaviour
{
    FirstPersonController playerController;
    HighlightController highlightController;

    public GameObject _player;

    private float _distanceToMove = 1f;
    private RaycastHit _hitLocker;

    private void Start()
    {
        playerController = _player.GetComponent<FirstPersonController>();
        highlightController = _player.GetComponent<HighlightController>();
    }

    /// <summary>
    /// AnimationEventから呼び出しを受けplayerをロッカーの中に隠す処理を行う
    /// </summary>
    void IsHide()
    {
        GameObject _locker = _hitLocker.transform.parent.gameObject;

        Vector3 _hidingPosition = new Vector3(_locker.transform.position.x, _player.transform.position.y, _locker.transform.position.z);
        _player.transform.position = _hidingPosition;
        _player.transform.Rotate(Vector3.up, 180f);

        playerController.enableHeadBob = false;
        playerController.playerCanMove = false;

        GetComponentInChildren<TextMeshPro>().text = "";
        GetComponent<Animator>().SetBool("Hide", false);

        highlightController._isHiding = true;
    }

    /// <summary>
    /// IsHideの逆の処理として隠れた位置から少し前（1ｆ）に身を表すためのスクリプト
    /// </summary>
    /// <param name="hitObject"></param>
    void IsOut()
    {
        //プレイヤーの位置をロッカーから指定した距離分前の位置に移す
        _player.transform.position = _player.transform.position + _player.transform.forward * _distanceToMove;
        GetComponentInChildren<TextMeshPro>().text = "F:Hide";

        playerController.enableHeadBob = true;
        playerController.playerCanMove = true;

        GetComponent<Animator>().SetBool("Out", false);

        highlightController._isHiding = false;
    }

    public void SetRaycastHit(RaycastHit hitObject)
    {
        _hitLocker = hitObject;
    }
}