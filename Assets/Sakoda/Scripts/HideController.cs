using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HideController : MonoBehaviour
{
    FirstPersonController playerController;
    HighlightController highlightController;
    //RaycastManager raycastManager;
    //RaycastHit _hitDoor;
    //Animator _doorAnimator;

    private float _distanceToMove = 1f;
    private bool hasExitReached;
    //private bool _isHiding;

    private void Start()
    {
        playerController = GetComponent<FirstPersonController>();
        highlightController = GetComponent<HighlightController>();
    }

    //private void Update()
    //{
    //    raycastManager.GetRaycastHitInfo();
    //    _hitDoor = raycastManager.GetRaycastHitInfo();

    //    if (_hitDoor.collider != null && _hitDoor.collider.CompareTag("Locker"))
    //    {
    //        _doorAnimator = _hitDoor.collider.GetComponent<Animator>();
    //    }

    //    if(highlightController._canAct && Input.GetKeyDown(KeyCode.F))
    //    {
    //        _doorAnimator.SetBool("Open", true);
    //    }

    //    if (_doorAnimator.GetCurrentAnimatorStateInfo(0).IsName("ExitState"))
    //    {
    //        hasExitReached = true;
    //    }

    //    if(hasExitReached && !_isHiding)
    //    {
    //        IsHide(_hitDoor);
    //    }
    //    else if(hasExitReached && _isHiding)
    //    {
    //        IsOut(_hitDoor);
    //    }
    //}

    /// <summary>
    /// HighlightController����Ray�����������I�u�W�F�N�g�������Ƃ��Ď󂯎��
    /// ���̃I�u�W�F�N�g�ɐg���B�����߂̃��\�b�h
    /// </summary>
    /// <param name="hitObject"></param>
    public void IsHide(RaycastHit hitObject)
    {
        GameObject _locker = hitObject.transform.parent.gameObject;

        Vector3 _hidingPosition = new Vector3(_locker.transform.position.x, transform.position.y, _locker.transform.position.z);
        transform.position = _hidingPosition;
        transform.Rotate(Vector3.up, 180f); //Quaternion.Euler(0, 180f, 0);

        playerController.enableHeadBob = false;
        playerController.playerCanMove = false;

        hitObject.collider.GetComponentInChildren<TextMeshPro>().text = "F:Out";
        //hitObject.collider.GetComponent<Animator>().SetBool("Close", true);

        highlightController._isHiding = true;
    }

    /// <summary>
    /// IsHide�̋t�̏����Ƃ��ĉB�ꂽ�ʒu���班���O�i1���j�ɐg��\�����߂̃X�N���v�g
    /// </summary>
    /// <param name="hitObject"></param>
    public void IsOut(RaycastHit hitObject)
    {
        //�v���C���[�̈ʒu�����b�J�[����w�肵���������O�̈ʒu�Ɉڂ�
        transform.position = transform.position + transform.forward * _distanceToMove;
        hitObject.collider.GetComponentInChildren<TextMeshPro>().text = "F:Hide";

        playerController.enableHeadBob = true;
        playerController.playerCanMove = true;

        //hitObject.collider.GetComponent<Animator>().SetBool("Close", true);

        highlightController._isHiding = false;
    }
}