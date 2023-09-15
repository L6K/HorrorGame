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

    private void Start()
    {
        playerController = _player.GetComponent<FirstPersonController>();
        highlightController = _player.GetComponent<HighlightController>();
    }

    /// <summary>
    /// HighlightControllerからRayが当たったオブジェクトを引数として受け取り
    /// そのオブジェクトに身を隠すためのメソッド
    /// </summary>
    /// <param name="hitObject"></param>
    void IsHide()
    {
        Vector3 _hidingPosition = new Vector3(transform.parent.position.x, _player.transform.position.y, transform.parent.position.z);
        _player.transform.position = _hidingPosition;
        _player.transform.Rotate(Vector3.up, 180f);


        //GameObject _locker = hitObject.transform.parent.gameObject;

        //Vector3 _hidingPosition = new Vector3(_locker.transform.position.x, transform.position.y, _locker.transform.position.z);
        //transform.position = _hidingPosition;
        //transform.Rotate(Vector3.up, 180f); //Quaternion.Euler(0, 180f, 0);

        playerController.enableHeadBob = false;
        playerController.playerCanMove = false;

        //hitObject.collider.
        GetComponentInChildren<TextMeshPro>().text = "F:Out";
        //hitObject.collider.GetComponent<Animator>().SetBool("Close", true);

        //highlightController._isHiding = true;
    }

    /// <summary>
    /// IsHideの逆の処理として隠れた位置から少し前（1ｆ）に身を表すためのスクリプト
    /// </summary>
    /// <param name="hitObject"></param>
    void IsOut()
    {
        //プレイヤーの位置をロッカーから指定した距離分前の位置に移す
        _player.transform.position = _player.transform.position + _player.transform.forward * _distanceToMove;
        //hitObject.collider.
        GetComponentInChildren<TextMeshPro>().text = "F:Hide";

        playerController.enableHeadBob = true;
        playerController.playerCanMove = true;

        //hitObject.collider.GetComponent<Animator>().SetBool("Close", true);

        highlightController._isHiding = false;
    }
}