using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �Q�[���ɖ߂�{�^���������AMain�V�[���ɑJ�ڂ��鏈��
/// </summary>
public class GoToMainScene : MonoBehaviour
{
    [SerializeField] private string _mainSceneName;
    public void GoToGame()
    {
        SceneManager.LoadScene(_mainSceneName);
    }
}
