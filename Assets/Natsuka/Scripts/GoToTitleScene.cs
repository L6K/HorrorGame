using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToTitleScene : MonoBehaviour
{
    public void GoToTitle()
    {
        SceneManager.LoadScene("Title");  // "TitleScene"はタイトルシーンの名前に置き換えてください。
    }
}