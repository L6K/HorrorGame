using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �]���r��collider�ƃh�A��collider���Փ˂�����Q�[���I�[�o�[������
/// </summary>
public class GameOver : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // �h�A�Ƃ̏Փ˂𔻒�
        if (other.gameObject.tag == "Door")
        {
            Debug.Log("�Փ�");
            SceneManager.LoadScene("GameOver");
        }
    }
}
