using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageManager : MonoBehaviour
{
    public Text _messageText;//メッセージのテキスト表示用
    public Text _nameLabel;//話者の名前表示用
    public GameObject _nextButton;
    public GameObject _mainUI;
    public GameObject _enemyMove;
    public FirstPersonController _firstPersonController;
    int _textPage;//メッセージのページ数
    int _currentPage;//現在のページ
    int _messageIndex;//メッセージ管理用引数
    [SerializeField] string[] _messages;//メッセージのページ
    // Start is called before the first frame update
    void Start()
    {
       // StartCoroutine(_WaitAMinute());
        _nextButton.SetActive(false);
        _nameLabel.enabled = false;
        _messageText.enabled = false;
        _currentPage = 0;

        _messageIndex = 0;
        _MessageStorage(_messageIndex);
        StartCoroutine(_TextChange());

    }

    // Update is called once per frame
    void Update()
    {
        if (_messageText.text == _messages[_currentPage])//1ページ内のテキストの出力が終わったとき
        {
            // マウスカーソルを表示状態にする
            Cursor.visible = true;

            // マウスカーソルのロックを解除する
            Cursor.lockState = CursorLockMode.None;
            _nextButton.SetActive(true);
            if (_currentPage == (_messages.Length - 1))//そのページが最後の時
            {

                Sprite _endSprite = Resources.Load<Sprite>("EndButton_L");
                Image _endImage = _nextButton.GetComponent<Image>();
                _endImage.sprite = _endSprite;

            }
        }
        else
        {
            
            _nextButton.SetActive(false);
        }
    }
   
    public void OnNextButtonClicked()
    {

        if (_currentPage < _messages.Length - 1)//テキストのページ処理
        {
            _currentPage++;
            _messageText.text = "";
            StartCoroutine(_TextChange());
        }
        else
        {
            _nextButton.SetActive(false);
            _nameLabel.text = "";
            _messageText.text = "";
            _mainUI.SetActive(true);
            _firstPersonController.playerCanMove = true;
            _enemyMove.SetActive(true);
           
        }
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    IEnumerator _TextChange()//テキスト送り用のコルーチン
    {
        foreach (char x in _messages[_currentPage].ToCharArray())
        {
            _messageText.text += x;
            //効果音を入れるならここ
            yield return new WaitForSeconds(0.1f);
        }
    }
    IEnumerator _WaitAMinute()
    {
        yield return new WaitForSeconds(1);
    }
    void _MessageStorage(int index)//メッセージ管理用の関数
    {
        _nameLabel.enabled = true;
        _messageText.enabled = true;
        _mainUI.SetActive(false);
        _firstPersonController.playerCanMove = false;
        _enemyMove.SetActive(false);
       
        switch (index)//管理引数に対応したメッセージを格納
        {
            case 0://スタート時のメッセージ
                _textPage = 1;
                // _messages = new string[_textPage];
                _nameLabel.text = "幽霊";
                // _messages[0] = "ピアノが弾きたい...";
                break;
        }
        _currentPage = 0;//ページの初期化
    }
}
