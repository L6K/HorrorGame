using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChasingPlayer : MonoBehaviour
{

    float maxRayDistance = 5f; // Rayの最大距離
    float fieldOfViewAngle = 45f; // 視界の角度（度数法）
    LayerMask hitLayer; // Rayがヒットを検出する対象のレイヤーマスク

    void Update()
    {
        // 敵の位置を開始点とする
        Vector3 startPos = transform.position;

        // 視界の開始角度と終了角度を計算
        float halfFOV = fieldOfViewAngle / 2f;
        Quaternion leftRayRotation = Quaternion.AngleAxis(-halfFOV, transform.up);
        Quaternion rightRayRotation = Quaternion.AngleAxis(halfFOV, transform.up);

        // 左端から右端までのRayを発射
        for (float angle = -halfFOV; angle <= halfFOV; angle += 1f) // 1度ずつ増やす
        {
            Vector3 rayDirection = leftRayRotation * transform.forward;

            // SphereCastを使用してRayを飛ばす
            RaycastHit hit;
            if (Physics.SphereCast(startPos, 0.5f, rayDirection, out hit, maxRayDistance))
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
            Debug.DrawRay(startPos, rayDirection * maxRayDistance, Color.red);

            // 次のRayの方向を計算
            leftRayRotation = Quaternion.AngleAxis(1f, transform.up) * leftRayRotation;
        }
    }
}

