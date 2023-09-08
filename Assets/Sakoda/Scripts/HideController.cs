using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HideController : MonoBehaviour
{
    private Animator animator;

    private bool _isHiding;
    private float _distanceToMove = 1.5f;

    /*
     * <summary>
     * HighlightManager����̌Ăяo�����󂯓���̏�������
     * �B���B��Ȃ��̓������s��
     * </summary>
     */
    public bool IsHiding(bool _isHidable, RaycastHit hitObject)
    {
        animator = hitObject.collider.GetComponentInChildren<Animator>();
        GameObject _locker = hitObject.transform.parent.gameObject;

        Debug.Log(_locker.transform.position);

        if (Input.GetKeyDown(KeyCode.F))
        {
            //���b�J�[�Ƃ̋����ŉB��邩�O�ɏo�邩�̔�����s��
            if (_isHiding)
            {
                //�v���C���[�̈ʒu�����b�J�[����w�肵���������O�̈ʒu�Ɉڂ�
                transform.position = transform.position + transform.forward * _distanceToMove;

                GetComponent<FirstPersonController>().playerCanMove = true;
                hitObject.collider.GetComponentInChildren<TextMeshPro>().text = "F:Hide";

                _isHiding = false;
                _isHidable = false;
            }
            else
            {
                Vector3 _hidingPosition = _locker.transform.position;
                transform.position = _hidingPosition;
                transform.rotation = Quaternion.Euler(0, 180f, 0);

                GetComponent<FirstPersonController>().playerCanMove = false;
                hitObject.collider.GetComponentInChildren<TextMeshPro>().text = "F:Out";

                _isHiding = true;
            }
        }

        //if (!animator.GetCurrentAnimatorStateInfo(0).IsName("door"))
        //{
        //    animator.enabled = false;
        //}

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
