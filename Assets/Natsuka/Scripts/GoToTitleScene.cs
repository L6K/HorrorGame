using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �^�C�g���ɖ߂�{�^���������A�^�C�g���V�[���ɑJ�ڂ��鏈��
/// </summary>
public class GoToTitleScene : MonoBehaviour
{
    public void GoToTitle()
    {
        SceneManager.LoadScene("Title");  // "TitleScene"�̓^�C�g���V�[���̖��O�ɒu�������Ă��������B
    }
}