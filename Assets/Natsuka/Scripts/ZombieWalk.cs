using UnityEngine;

/// <summary>
/// Mainシーンでゾンビが活性化した後、廊下から音楽室に向かって歩くスクリプト
/// </summary>
public class ZombieWalk : MonoBehaviour
{
    public float _speed = 1.0f; // 移動速度
    public bool _canZombieWalk = true;

    void FixedUpdate()
    {
        if(_canZombieWalk)
        {
            // キャラクターの現在の座標を取得
            Vector3 currentPosition = transform.position;

            // X座標を増加させる
            currentPosition.z += _speed * Time.fixedDeltaTime;

            // 新しい座標を適用
            transform.position = currentPosition;
        }
        
    }
}
