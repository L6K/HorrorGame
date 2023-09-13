using UnityEngine;

/// <summary>
/// �]���r���v���C���[���R��A�j���[�V�����ɑJ�ڂ����ۂɁA�]���r�̍��W��ύX����X�N���v�g
/// </summary>
public class AnimationTrigger : MonoBehaviour
{
    private Animator _animator; //�]���r�̃A�j���[�^�[
    private float _speed = 0.2f;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("boxing"))
        {
            // �L�����N�^�[�̌��݂̍��W���擾
            Vector3 currentPosition = transform.position;

            currentPosition.x += _speed * Time.fixedDeltaTime;

            // �V�������W��K�p
            transform.position = currentPosition;

        }
        
    }
}