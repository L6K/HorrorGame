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
    public FirstPersonController _firstPersonController;
    public GameObject _triggerKey;
    public GameObject _triggerOpen;
    public GameObject _zombie;
    public bool _isEvent;
    public bool _isKeyGet;
    public bool _clear;
    public bool _isPianoOpen;
    ItemHandle _itemHandle;
    public GameObject _grandPiano;
    private Piano _piano;
    int _currentPage=0;//現在のページ
    int _messageIndex;//メッセージ管理用引数
    List<string> _messages;//メッセージのページ
    List<bool> _isEvents;//イベント用の判定
    int _totalEvent = 4;

    // セーブデータ用
    private SaveDataManager _saveDataManager;
    [SerializeField] private GameObject _saveDataManagerO;

    // Start is called before the first frame update
    void Start()
    {
       // StartCoroutine(_WaitAMinute());
        _nextButton.SetActive(false);
        _nameLabel.enabled = false;
        _messageText.enabled = false;
        _messages = new List<string>();
        _isEvents = new List<bool>();
        for(int i=0;i<_totalEvent;i++)
        {
            _isEvents.Add(false);
        }
        _isEvent = false;
        
        _messageIndex = 0;
        _MessageStorage(_messageIndex);
        _itemHandle = _firstPersonController.GetComponent<ItemHandle>();
        _piano = _grandPiano.GetComponent<Piano>();

        // セーブデータ用コンポーネント取得
        _saveDataManager = _saveDataManagerO.GetComponent<SaveDataManager>();
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
        if(_isEvent)
        {
            _EventManager();
            _isEvent = false;
        }
        if(_itemHandle._isKeyGet&&!(_isEvents[1]))
        {
            _isEvent = true;
            _isKeyGet = true;
            _isEvents[1] = true;
        }

        if (_zombie.GetComponent<GameOver>()._clear == 1 && !(_isEvents[2])) //ロッカーでゾンビから逃げれたとき
        {
            Debug.Log(_zombie.GetComponent<GameOver>()._clear);
            _clear = true;
            _zombie.GetComponent<GameOver>()._clear = 2;
            _EventManager();
            _isEvents[2] = true;
        }
        if(_piano._isPianoOpen && !(_isEvents[3]))
        {
            _isEvent = true;
            _isPianoOpen = true;
            _isEvents[3] = true;
        }
        
    }
   
    public void OnNextButtonClicked()
    {
        Debug.Log("A");
        if (_currentPage < _messages.Count - 1)//テキストが残っているとき
        {
            Debug.Log("X");
            _currentPage++;
            _messageText.text = "";
            Debug.Log(_currentPage+1+"/"+_messages.Count);
            StartCoroutine(_TextChange());
        }
        else//テキストが終わったとき
        {
            Debug.Log("Y");
            _nextButton.SetActive(false);
            _nameLabel.text = "";
            _messageText.text = "";
            _mainUI.SetActive(true);
            _firstPersonController.playerCanMove = true;
            _firstPersonController.isCameraMove = true;
            _firstPersonController.enableHeadBob = true;
            Debug.Log(_currentPage +1+ "/" + _messages.Count);
            Sprite _endSprite = Resources.Load<Sprite>("NextButton_L");
            Image _endImage = _nextButton.GetComponent<Image>();
            _endImage.sprite = _endSprite;
        }
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Debug.Log("Z");
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
    void _EventManager()
    {

        if(_isKeyGet)
        {
            _messageIndex = 1;
            _MessageStorage(_messageIndex);
            _isKeyGet = false;
            _zombie.SetActive(true);
        }
        else if (_clear)
        {
            _messageIndex = 2;
            _MessageStorage(_messageIndex);
            _clear = false;
        }
        else if (_isPianoOpen)
        {
            _messageIndex = 3;
            _MessageStorage(_messageIndex);
            _isPianoOpen=false;
        }
    }
    void _MessageStorage(int index)//メッセージ管理用の関数
    {
        _nameLabel.enabled = true;
        _messageText.enabled = true;
        _mainUI.SetActive(false);
        _firstPersonController.playerCanMove = false;
        _zombie.SetActive(false);
        _firstPersonController.isCameraMove = false;
        _firstPersonController.enableHeadBob = false;
        switch (index)//管理引数に対応したメッセージを格納
        {
            case 0://スタート時のメッセージ
                
                _nameLabel.text = "???";
                _messages.Add("あなたこの学校の教師？");
                _messages.Add("ピアノを弾きたいんだけど、\n鍵が見つからないの...");
                _messages.Add("あなた教師なら鍵の場所わかるよね？\nお願い、探して！！");
                
                break;
            case 1://ピアノのカギ取得時のメッセージ
                
                _currentPage++;
                _nameLabel.text = "???";
                _messages.Add("まずい、良くないものが来るわ。\nどこかに隠れないと...");
                
               
                break;
            case 2://ゾンビを回避した時のメッセージ

                _currentPage++;
                _nameLabel.text = "???";
                _messages.Add("…行ったみたいね。\nあれはこの場所をうろついているの。気を付けて");


                break;
            case 3://ピアノが開いた時のメッセージ

                _currentPage++;
                _nameLabel.text = "???";
                _messages.Add("やったわ！これであの時の曲が弾けるわ！");
                _messages.Add("ねぇ次は美術室に行きたいんだけど、ついてきてくれない？");
                PlayerPrefs.SetString("_isMusicClear", "Clear");
                _saveDataManager.WriteSaveData(Story.musicRoom);
                break;
        }
        StartCoroutine(_TextChange());
    }

}
