using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChasingPlayer : MonoBehaviour
{

    float _maxRayDistance = 5f; // Rayの最大距離
    float _fieldOfViewAngle = 45f; // 視界の角度（度数法）
    public LayerMask _hitPlayer; // Rayがヒットを検出する対象のレイヤーマスク

    void Update()
    {
        // 敵の位置を開始点とする
        Vector3 _startPos = transform.position + transform.up * 0.1f;

        // 視界の開始角度と終了角度を計算
        float _halfFOV = _fieldOfViewAngle / 2f;
        Quaternion _leftRayRotation = Quaternion.AngleAxis(-_halfFOV, transform.up);
        Quaternion _rightRayRotation = Quaternion.AngleAxis(_halfFOV, transform.up);

        // 左端から右端までのRayを発射
        for (float _angle = -_halfFOV; _angle <= _halfFOV; _angle += 1f) // 1度ずつ増やす
        {
            Vector3 _rayDirection = _leftRayRotation * transform.forward;

            // SphereCastを使用してRayを飛ばす
            RaycastHit hit;
            if (Physics.SphereCast(_startPos, 0.5f, _rayDirection, out hit, _maxRayDistance, _hitPlayer))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    PlayerPrefs.SetFloat("zombiePositionX", transform.parent.position.x);
                    PlayerPrefs.SetFloat("zombiePositionY", transform.parent.position.y);
                    PlayerPrefs.SetFloat("zombiePositionZ", transform.parent.position.z);

                    SceneManager.LoadScene("GameOver");
                }
            }

            // Rayの可視化（シーンビューで見るために追加）
            Debug.DrawRay(_startPos, _rayDirection * _maxRayDistance, Color.red);

            // 次のRayの方向を計算
            _leftRayRotation = Quaternion.AngleAxis(1f, transform.up) * _leftRayRotation;
        }
    }
}

