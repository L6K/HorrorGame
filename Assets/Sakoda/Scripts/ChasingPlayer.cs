using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChasingPlayer : MonoBehaviour
{

    float _maxRayDistance = 5f; // Ray�̍ő勗��
    float _fieldOfViewAngle = 45f; // ���E�̊p�x�i�x���@�j
    public LayerMask _hitPlayer; // Ray���q�b�g�����o����Ώۂ̃��C���[�}�X�N

    void Update()
    {
        // �G�̈ʒu���J�n�_�Ƃ���
        Vector3 _startPos = transform.position + transform.up * 0.1f;

        // ���E�̊J�n�p�x�ƏI���p�x���v�Z
        float _halfFOV = _fieldOfViewAngle / 2f;
        Quaternion _leftRayRotation = Quaternion.AngleAxis(-_halfFOV, transform.up);
        Quaternion _rightRayRotation = Quaternion.AngleAxis(_halfFOV, transform.up);

        // ���[����E�[�܂ł�Ray�𔭎�
        for (float _angle = -_halfFOV; _angle <= _halfFOV; _angle += 1f) // 1�x�����₷
        {
            Vector3 _rayDirection = _leftRayRotation * transform.forward;

            // SphereCast���g�p����Ray���΂�
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

            // Ray�̉����i�V�[���r���[�Ō��邽�߂ɒǉ��j
            Debug.DrawRay(_startPos, _rayDirection * _maxRayDistance, Color.red);

            // ����Ray�̕������v�Z
            _leftRayRotation = Quaternion.AngleAxis(1f, transform.up) * _leftRayRotation;
        }
    }
}

