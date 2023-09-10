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
     * HighlightManager����̌Ăяo�����󂯓���̏�������
     * �B���B��Ȃ��̓������s��
     * </summary>
     */
    public bool IsHiding(bool _isHidable, RaycastHit hitObject)
    {
        _doorAnimator = hitObject.collider.GetComponent<Animator>();
        GameObject _locker = hitObject.transform.parent.gameObject;
        FirstPersonController playerController = GetComponent<FirstPersonController>();

        if (Input.GetKeyDown(KeyCode.F))
        {
            //���b�J�[�Ƃ̋����ŉB��邩�O�ɏo�邩�̔�����s��
            if (_isHiding)
            {

                //�v���C���[�̈ʒu�����b�J�[����w�肵���������O�̈ʒu�Ɉڂ�
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