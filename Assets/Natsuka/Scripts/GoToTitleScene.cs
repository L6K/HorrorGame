using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToTitleScene : MonoBehaviour
{
    public void GoToTitle()
    {
        SceneManager.LoadScene("Title");  // "TitleScene"�̓^�C�g���V�[���̖��O�ɒu�������Ă��������B
    }
}