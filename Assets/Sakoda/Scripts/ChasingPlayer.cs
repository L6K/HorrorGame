using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChasingPlayer : MonoBehaviour
{

    float maxRayDistance = 5f; // Ray�̍ő勗��
    float fieldOfViewAngle = 45f; // ���E�̊p�x�i�x���@�j
    LayerMask hitLayer; // Ray���q�b�g�����o����Ώۂ̃��C���[�}�X�N

    void Update()
    {
        // �G�̈ʒu���J�n�_�Ƃ���
        Vector3 startPos = transform.position;

        // ���E�̊J�n�p�x�ƏI���p�x���v�Z
        float halfFOV = fieldOfViewAngle / 2f;
        Quaternion leftRayRotation = Quaternion.AngleAxis(-halfFOV, transform.up);
        Quaternion rightRayRotation = Quaternion.AngleAxis(halfFOV, transform.up);

        // ���[����E�[�܂ł�Ray�𔭎�
        for (float angle = -halfFOV; angle <= halfFOV; angle += 1f) // 1�x�����₷
        {
            Vector3 rayDirection = leftRayRotation * transform.forward;

            // SphereCast���g�p����Ray���΂�
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

            // Ray�̉����i�V�[���r���[�Ō��邽�߂ɒǉ��j
            Debug.DrawRay(startPos, rayDirection * maxRayDistance, Color.red);

            // ����Ray�̕������v�Z
            leftRayRotation = Quaternion.AngleAxis(1f, transform.up) * leftRayRotation;
        }
    }
}

