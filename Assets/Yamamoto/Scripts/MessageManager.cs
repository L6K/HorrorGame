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
    int _currentPage=0;//現在のページ
    int _messageIndex;//メッセージ管理用引数
    List<string> _messages;//メッセージのページ
    // Start is called before the first frame update
    void Start()
    {
       // StartCoroutine(_WaitAMinute());
        _nextButton.SetActive(false);
        _nameLabel.enabled = false;
        _messageText.enabled = false;
        _messages = new List<string>();

        _messageIndex = 0;
        _MessageStorage(_messageIndex);
       

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
            if (_currentPage == (_messages.Count - 1))//そのページが最後の時
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _messageIndex = 1;
            _MessageStorage(_messageIndex);
        }
    }
   
    public void OnNextButtonClicked()
    {

        if (_currentPage < _messages.Count - 1)//テキストが残っているとき
        {
            _currentPage++;
            _messageText.text = "";
            Debug.Log(_currentPage+1+"/"+_messages.Count);
            StartCoroutine(_TextChange());
        }
        else//テキストが終わったとき
        {
            
            _nextButton.SetActive(false);
            _nameLabel.text = "";
            _messageText.text = "";
            _mainUI.SetActive(true);
            _firstPersonController.playerCanMove = true;
            _enemyMove.SetActive(true);
            _firstPersonController.isCameraMove = true;
            Debug.Log(_currentPage +1+ "/" + _messages.Count);
            Sprite _endSprite = Resources.Load<Sprite>("NextButton_L");
            Image _endImage = _nextButton.GetComponent<Image>();
            _endImage.sprite = _endSprite;
        }
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    IEnumerator _TextChange()//テキスト送り用のコルーチン
    {
        foreach (char x in _messages[_currentPage].ToCharArray())//
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
        _firstPersonController.isCameraMove = false;
        switch (index)//管理引数に対応したメッセージを格納
        {
            case 0://スタート時のメッセージ
                _textPage = 1;
                _nameLabel.text = "幽霊";
                _messages.Add("ピアノが弾きたい...");
                Debug.Log("Page:"+_messages.Count);
                break;
            case 1:
                _textPage = 2;
                _currentPage++;
                _nameLabel.text = "自分";
                _messages.Add("(疲れたなぁ...)");
                _messages.Add("(お腹もすいたし...)");
                Debug.Log("Page:" + _messages.Count);
                break;
        }
        StartCoroutine(_TextChange());
    }
}
