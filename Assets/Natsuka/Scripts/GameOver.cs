using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �]���r��collider�ƃh�A��collider���Փ˂�����Q�[���I�[�o�[������
/// </summary>
public class GameOver : MonoBehaviour
{
    public int _clear = 0;
    public GameObject _player;
    public GameObject _mm;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        // �h�A�Ƃ̏Փ˂𔻒�
        if (other.gameObject.tag == "Door")
        {
            if (_player.GetComponent<HighlightController>()._isHiding) //���b�J�[�ɉB��Ă���Ƃ�
            {
                
                gameObject.SetActive(false);
                _mm.GetComponent<MessageManager>().MessageManage(2);
            }
            else //�Q�[���I�[�o�[��
            {
                Debug.Log("�Փ�");
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}