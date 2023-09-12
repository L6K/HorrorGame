using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieWalk : MonoBehaviour
{
    public float _speed = 1.0f; // �ړ����x
    public bool _canZombieWalk = true;

    void FixedUpdate()
    {
        if(_canZombieWalk)
        {
            ZombieStart();
        }
        
    }

    void ZombieStart()
    {
        // �L�����N�^�[�̌��݂̍��W���擾
        Vector3 currentPosition = transform.position;

        // X���W�𑝉�������
        currentPosition.z += _speed * Time.fixedDeltaTime;

        // �V�������W��K�p
        transform.position = currentPosition;
    }
}
