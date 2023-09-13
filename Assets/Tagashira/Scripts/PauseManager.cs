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
        // 現在のカーソルの位置以外のカーソルを無効化
        for (int i = 0; i < _cursols.Length; i++)
        {
            _cursols[i].SetActive(false);

            if (i == (int)_cursolPosition)
            {
                _cursols[i].SetActive(true);
            }
        }

        // コントロールキーを押すとポーズ画面になる(後でESCに変更ののち削除)
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            Time.timeScale = 0;
            _pauseCanvas.SetActive(true);
            _isPause = true;

            // マウスカーソルを非表示状態にする
            Cursor.visible = false;

            // マウスカーソルをロックする
            Cursor.lockState = CursorLockMode.Locked;
        }

        // ポーズ画面の挙動
        if (_isPause == true)
        {
            // Wキーもしくは↑キーでカーソルを上方向に移動、Sキーもしくは↓キーでカーソルを下方向に移動
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

            // スペースキー押下で現在カーソルがある位置に書いてある処理を行う
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SelectPauseAction();
            }
        }
    }

    /// <summary>
    /// ポーズ画面で決定操作(とりあえずスペースキー)をした際に動作を決定するメソッド
    /// </summary>
    void SelectPauseAction()
    {
        // 有効なカーソルの位置で処理を選択
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
    /// ゲームを再開するメソッド
    /// </summary>
    void RestertGame()
    {
        Time.timeScale = 1;
        _pauseCanvas.SetActive(false);
        _isPause = false;

        // マウスカーソルを表示状態にする
        Cursor.visible = true;

        // マウスカーソルのロックを解除する
        Cursor.lockState = CursorLockMode.None;
    }

    /// <summary>
    /// タイトルに戻るメソッド
    /// </summary>
    void BackToTitle()
    {
        // マウスカーソルを表示状態にする
        Cursor.visible = true;

        // マウスカーソルのロックを解除する
        Cursor.lockState = CursorLockMode.None;

        // タイトルシーンに切り替え
        SceneManager.LoadScene("Title");
    }
}
