using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �]���r��collider�ƃh�A��collider���Փ˂�����Q�[���I�[�o�[������
/// </summary>
public class GameOver : MonoBehaviour
{
    public bool _clear = false;
    public GameObject _player;

    private void OnTriggerEnter(Collider other)
    { 
        // �h�A�Ƃ̏Փ˂𔻒�
        if (other.gameObject.tag == "Door")
        {
            if (_player.GetComponent<HighlightController>()._isHiding) //���b�J�[�ɉB��Ă���Ƃ�
            {
                Debug.Log("good!");
                gameObject.SetActive(false);
                _clear = true;
            }
            else //�Q�[���I�[�o�[��
            {
                Debug.Log("�Փ�");
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}
