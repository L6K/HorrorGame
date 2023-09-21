using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageManager : MonoBehaviour
{
    public Text _messageText;//メッセージのテキスト表示用
    public Text _nameLabel;//話者の名前表示用
    public GameObject _nextButton;//次へボタン
    public GameObject _mainUI;//UI関連
    public GameObject fpc;//自分
    public GameObject _zombie;//ゾンビ
    int _currentPage=0;//現在のページ
    int _messageIndex;//メッセージ管理用引数
    List<string> _messages;//メッセージのページ
    int _totalEvent = 4;
    private bool _first=true;
    // Start is called before the first frame update
    void Start()
    {
       // StartCoroutine(_WaitAMinute());
        _nextButton.SetActive(false);
        _nameLabel.enabled = false;
        _messageText.enabled = false;
        _messages = new List<string>();
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
    }
   
    public void OnNextButtonClicked() //次へボタン押下時
    {
        if (_currentPage < _messages.Count - 1)//テキストが残っているとき
        {
            _currentPage++;
            _messageText.text = "";
            StartCoroutine(_TextChange());
        }
        else//テキストが終わったとき
        {
            _nextButton.SetActive(false);
            _nameLabel.text = "";
            _messageText.text = "";
            _mainUI.SetActive(true);
            fpc.GetComponent<FirstPersonController>().enabled=true;
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
    public void MessageManage(int index)//メッセージ管理用の関数
    {
        _nameLabel.enabled = true;
        _messageText.enabled = true;
        _mainUI.SetActive(false);
        _zombie.SetActive(false);
        fpc.GetComponent<FirstPersonController>().enabled = false;
        _currentPage++;
        if(_first)
        {
            _first = false;
            _messages.Add("");
        }
        switch (index)//管理引数に対応したメッセージを格納
        {
            case 0://スタート時のメッセージ
                _nameLabel.text = "???";
                _messages.Add("あなたこの学校の教師？");
                _messages.Add("ピアノを弾きたいんだけど、\n鍵が見つからないの...");
                _messages.Add("あなた教師なら鍵の場所わかるよね？\nお願い、探して！！");
                
                break;
            case 1://ピアノのカギ取得時のメッセージ
                _nameLabel.text = "???";
                _messages.Add("まずい、良くないものが来るわ。\nどこかに隠れないと...");
                              
                break;
            case 2://ゾンビを回避した時のメッセージ
                _nameLabel.text = "???";
                _messages.Add("…行ったみたいね。\nあれはこの場所をうろついているの。気を付けて");

                break;
            case 3://ピアノが開いた時のメッセージ
                _nameLabel.text = "???";
                _messages.Add("やったわ！これであの時の曲が弾けるわ！");
                _messages.Add("ねぇ次は美術室に行きたいんだけど、ついてきてくれない？");
                PlayerPrefs.SetString("_isMusicClear", "Clear");

                break;
        }
        StartCoroutine(_TextChange());
    }
}
