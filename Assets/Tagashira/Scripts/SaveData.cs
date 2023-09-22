using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData
{
    // �v���C���[�ʒu���
    public Vector3 _playerPosition;
    public Quaternion _playerRotate;

    // �]���r�ʒu���
    public Vector3 _zombiePosition;
    public Quaternion _zombieRotate;

    // �����i���
    public List<ItemData> _belongings;

    // �t���O���
    public bool _isMusicRoomClear;
    public bool _isInfinitedStair;
}
