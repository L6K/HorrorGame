using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHighlighter : MonoBehaviour
{
    private Ray _ray;

    // Update is called once per frame
    void Update()
    {
        //��ʒ��S������Ray���o��������
        _ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        Debug.DrawLine(_ray.origin, _ray.origin + _ray.direction * 10, Color.red);
    }

    /*
     * <summary>
     * �e�I�u�W�F�N�g�����R���C�_�[��player����������A�������s��
     * </summary>
     */
    private void OnTriggerStay(Collider other)
    {
        //ray����������object�̏����i�[����
        RaycastHit _hitObject;
        //player�̎��E�̒���
        float _playerVisibility = 10.0f;
 
        if (other.CompareTag("ItemCollider"))
        {
            Outline outline = other.GetComponentInChildren<Outline>();
            Debug.Log(outline);
            if (Physics.Raycast(_ray, out _hitObject, _playerVisibility))
            {
                if (_hitObject.collider.CompareTag("Item"))
                {
                    Debug.Log(_hitObject.collider.gameObject);
                    outline.enabled = true;
                }
                else
                {
                    outline.enabled = false;
                }
            }
        }
    }

    /*
     * <summary>
     * player���Ώۂ�object���痣�ꂽ�Ƃ��ɏ������s��
     * </summary>
     */
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ItemCollider"))
        {
            other.GetComponentInChildren<Outline>().enabled = false;
        }
    }
}
