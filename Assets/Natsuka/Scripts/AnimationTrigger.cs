using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    private Animator _animator;
    private float _speed = 0.2f;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("boxing"))
        {
            // キャラクターの現在の座標を取得
            Vector3 currentPosition = transform.position;

            currentPosition.x += _speed * Time.fixedDeltaTime;

            // 新しい座標を適用
            transform.position = currentPosition;

        }
        
    }
}