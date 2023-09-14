using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    private const int PAUSE_MAX_NUM = 1;

    private bool _isPause;
    private Pause _cursolPosition;

    [SerializeField] private GameObject _pauseCanvas;
    [SerializeField] private GameObject[] _cursols;

    private void Start()
    {
        _pauseCanvas.SetActive(false);

        _cursolPosition = Pause.game;
    }

    void Update()
    {
        // ���݂̃J�[�\���̈ʒu�ȊO�̃J�[�\���𖳌���
        for (int i = 0; i < _cursols.Length; i++)
        {
            _cursols[i].SetActive(false);

            if (i == (int)_cursolPosition)
            {
                _cursols[i].SetActive(true);
            }
        }

        // �R���g���[���L�[�������ƃ|�[�Y��ʂɂȂ�(���ESC�ɕύX�̂̂��폜)
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            Time.timeScale = 0;
            _pauseCanvas.SetActive(true);
            _isPause = true;

            // �}�E�X�J�[�\�����\����Ԃɂ���
            Cursor.visible = false;

            // �}�E�X�J�[�\�������b�N����
            Cursor.lockState = CursorLockMode.Locked;
        }

        // �|�[�Y��ʂ̋���
        if (_isPause == true)
        {
            // W�L�[�������́��L�[�ŃJ�[�\����������Ɉړ��AS�L�[�������́��L�[�ŃJ�[�\�����������Ɉړ�
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                if ((int)_cursolPosition == 0)
                {
                    _cursolPosition = (Pause)PAUSE_MAX_NUM;
                }
                else
                {
                    _cursolPosition = (Pause)((int)_cursolPosition - 1);
                }
            }

            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                if ((int)_cursolPosition == PAUSE_MAX_NUM)
                {
                    _cursolPosition = (Pause)0;
                }
                else
                {
                    _cursolPosition = (Pause)((int)_cursolPosition + 1);
                }
            }

            // �X�y�[�X�L�[�����Ō��݃J�[�\��������ʒu�ɏ����Ă��鏈�����s��
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SelectPauseAction();
            }
        }
    }

    /// <summary>
    /// �|�[�Y��ʂŌ��葀��(�Ƃ肠�����X�y�[�X�L�[)�������ۂɓ�������肷�郁�\�b�h
    /// </summary>
    void SelectPauseAction()
    {
        // �L���ȃJ�[�\���̈ʒu�ŏ�����I��
        switch (_cursolPosition)
        {
            case Pause.game:
                RestertGame();
                break;

            case Pause.title:
                BackToTitle();
                break;

            default:
                break;
        }
    }

    /// <summary>
    /// �Q�[�����ĊJ���郁�\�b�h
    /// </summary>
    void RestertGame()
    {
        Time.timeScale = 1;
        _pauseCanvas.SetActive(false);
        _isPause = false;

        // �}�E�X�J�[�\����\����Ԃɂ���
        Cursor.visible = true;

        // �}�E�X�J�[�\���̃��b�N����������
        Cursor.lockState = CursorLockMode.None;
    }

    /// <summary>
    /// �^�C�g���ɖ߂郁�\�b�h
    /// </summary>
    void BackToTitle()
    {
        // �}�E�X�J�[�\����\����Ԃɂ���
        Cursor.visible = true;

        // �}�E�X�J�[�\���̃��b�N����������
        Cursor.lockState = CursorLockMode.None;

        // �^�C�g���V�[���ɐ؂�ւ�
        SceneManager.LoadScene("Title");
    }
}
