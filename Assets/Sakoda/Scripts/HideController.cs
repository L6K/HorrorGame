using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HideController : MonoBehaviour
{
    private FirstPersonController playerController;

    private float _distanceToMove = 1f;

    private void Start()
    {
        playerController = GetComponent<FirstPersonController>();
    }

    public void IsHide(RaycastHit hitObject)
    {
        GameObject _locker = hitObject.transform.parent.gameObject;

        Vector3 _hidingPosition = new Vector3(_locker.transform.position.x, transform.position.y, _locker.transform.position.z);
        transform.position = _hidingPosition;
        transform.Rotate(Vector3.up, 180f); //Quaternion.Euler(0, 180f, 0);

        playerController.enableHeadBob = false;
        playerController.playerCanMove = false;

        hitObject.collider.GetComponentInChildren<TextMeshPro>().text = "F:Out";
        hitObject.collider.GetComponent<Animator>().SetBool("Close", true);

        gameObject.GetComponent<HighlightController>()._isHiding = true;
    }

    public void IsOut(RaycastHit hitObject)
    {
        //プレイヤーの位置をロッカーから指定した距離分前の位置に移す
        transform.position = transform.position + transform.forward * _distanceToMove;
        hitObject.collider.GetComponentInChildren<TextMeshPro>().text = "F:Hide";

        playerController.enableHeadBob = true;
        playerController.playerCanMove = true;

        hitObject.collider.GetComponent<Animator>().SetBool("Close", true);

        gameObject.GetComponent<HighlightController>()._isHiding = false;
    }
}