using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// タイトルに戻るボタン押下時、タイトルシーンに遷移する処理
/// </summary>
public class GoToTitleScene : MonoBehaviour
{
    public void GoToTitle()
    {
        SceneManager.LoadScene("Title");  // "TitleScene"はタイトルシーンの名前に置き換えてください。
    }
}