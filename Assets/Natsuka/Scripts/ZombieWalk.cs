using UnityEngine;

/// <summary>
/// Main�V�[���Ń]���r��������������A�L�����特�y���Ɍ������ĕ����X�N���v�g
/// </summary>
public class ZombieWalk : MonoBehaviour
{
    public float _speed = 1.0f; // �ړ����x
    public bool _canZombieWalk = true;

    void FixedUpdate()
    {
        if(_canZombieWalk)
        {
            // �L�����N�^�[�̌��݂̍��W���擾
            Vector3 currentPosition = transform.position;

            // X���W�𑝉�������
            currentPosition.z += _speed * Time.fixedDeltaTime;

            // �V�������W��K�p
            transform.position = currentPosition;
        }
        
    }
}
