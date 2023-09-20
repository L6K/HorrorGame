using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �]���r��collider�ƃh�A��collider���Փ˂�����Q�[���I�[�o�[������
/// </summary>
public class GameOver : MonoBehaviour
{
    public GameObject _player;

    private void OnTriggerEnter(Collider other)
    { 
        // �h�A�Ƃ̏Փ˂𔻒�
        if (other.gameObject.tag == "Door")
        {
            if (_player.GetComponent<HighlightController>()._isHiding)
            {
                
                gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("�Փ�");
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}
