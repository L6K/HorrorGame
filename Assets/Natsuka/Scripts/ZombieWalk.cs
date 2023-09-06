using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieWalk : MonoBehaviour
{
    public float _speed = 1.0f; // 移動速度

    void FixedUpdate()
    {
        // キャラクターの現在の座標を取得
        Vector3 currentPosition = transform.position;

        // X座標を増加させる
        currentPosition.x += _speed * Time.fixedDeltaTime;

        // 新しい座標を適用
        transform.position = currentPosition;
    }
}
