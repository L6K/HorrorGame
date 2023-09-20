using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ゲームに戻るボタン押下時、Mainシーンに遷移する処理
/// </summary>
public class GoToMainScene : MonoBehaviour
{
    [SerializeField] private string _mainSceneName;
    public void GoToGame()
    {
        SceneManager.LoadScene(_mainSceneName);
    }
}
