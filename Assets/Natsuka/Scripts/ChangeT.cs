using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeT : MonoBehaviour
{

    public GameObject fpc;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        Vector3 newPosition = fpc.transform.position;  // ���݂̈ʒu���R�s�[
        newPosition.y += 3f;  // y���W���X�V
        fpc.transform.position = newPosition;  // �V�����ʒu��ݒ�
    }
}
