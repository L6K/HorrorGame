using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// ���̃N���X�ł̓]���r�Ɍ�����A�]���r�ɎE���ꂽ���̎����̎��_��������ɕύX����
/// </summary>

public class DeadController : MonoBehaviour
{
    GameObject _enemy; //�]���r
    GameObject _me; //�J�����̐e
    GameObject _meCamera; //�J����
    Transform _meRotation; //�J�����p�x

    // Start is called before the first frame update
    void Start()
    {
        _enemy = GameObject.Find("Zombie1"); //�]���r�I�u�W�F�N�g���擾
        _me = GameObject.Find("FirstPersonController"); //�J�����̐e�I�u�W�F�N�g���擾
        GameObject parentObject = GameObject.Find("ParentObjectName"); // �e�I�u�W�F�N�g�̖��O
        if (parentObject != null)
        {
            Transform childTransform = parentObject.transform.Find("PlayerCamera"); // �q�I�u�W�F�N�g�̖��O
            if (childTransform != null)
            {
                _meCamera = childTransform.GameObject();
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
