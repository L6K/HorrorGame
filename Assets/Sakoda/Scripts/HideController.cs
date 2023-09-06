using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HideController : MonoBehaviour
{
    public GameObject locker;
    private Animator animator;

    private bool _isHiding;
    private Vector3 _originalPosition;

    public void Hiding()
    {
        _isHiding = transform.position == locker.transform.position;

        animator = locker.GetComponentInChildren<Animator>();
        _originalPosition = transform.position;

        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("f");
            if (_isHiding)
            {
                transform.position = _originalPosition;
            }
            else
            {
                //animator.enabled = true;
                Vector3 _hidingPosition = locker.transform.position;
                transform.position = _hidingPosition;
                transform.rotation = Quaternion.Euler(0, 180f, 0);
            }
        }
    }
}
