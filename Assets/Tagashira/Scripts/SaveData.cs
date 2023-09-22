using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData
{
    // プレイヤー位置情報
    public Vector3 _playerPosition;
    public Quaternion _playerRotate;

    // ゾンビ位置情報
    public Vector3 _zombiePosition;
    public Quaternion _zombieRotate;

    // 所持品情報
    public List<ItemData> _belongings;

    // フラグ情報
    public bool _isMusicRoomClear;
    public bool _isInfinitedStair;
}
