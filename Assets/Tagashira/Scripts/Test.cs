using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        GameObject obj = null;
        string rightRoom = "";
        string leftRoom = "";
        Rigidbody rb = null;
        string roomName = null;

        // �^�O���v���C���[�Ȃ�Փ˂����I�u�W�F�N�g���擾
        if (other.gameObject.tag == "Player")
        {
            obj = other.gameObject;
            rb = other.GetComponent<Rigidbody>();
        }

        // �擾�����I�u�W�F�N�g�̈ړ��������擾���A�����̖��O����ύX
        if (obj != null)
        {
            if (rb.velocity.x >= 0) // �E�����ɓ����Ȃ�
            {
                roomName = rightRoom;
            }
            else�@   // �������ɓ����Ȃ�
            {
                roomName = leftRoom;
            }
        }
    }
}
