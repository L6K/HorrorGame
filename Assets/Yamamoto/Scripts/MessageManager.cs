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
    int _currentPage = 0;//現在のページ
    List<string> _messages;//メッセージのページ
    private bool _first = true;
    private int _index;

    // セーブデータ用フィールド
    [SerializeField] private GameObject _saveDataManagerO;
    private SaveDataManager _saveDataManager;

    // Start is called before the first frame update
    void Start()
    {
        _nextButton.SetActive(false);
        _nameLabel.enabled = false;
        _messageText.enabled = false;
        _messages = new List<string>();

        // セーブデータ用コンポーネントを取得
        _saveDataManager = _saveDataManagerO.GetComponent<SaveDataManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_messages.Count!=0)
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
    }

    public void OnNextButtonClicked() //次へボタン押下時
    {
        if (_currentPage < _messages.Count - 1)//テキストが残っているとき
        {
            _currentPage++;
            _messageText.text = "";
            StartCoroutine(_TextChange());
        } 
        else if (_index == 2)
        {
            _nextButton.SetActive(false);
            _nameLabel.text = "";
            _messageText.text = "";
            _mainUI.SetActive(true);
            fpc.GetComponent<FirstPersonController>().isCameraMove = true;
            Debug.Log(_currentPage + 1 + "/" + _messages.Count);
            Sprite _endSprite = Resources.Load<Sprite>("NextButton_L");
            Image _endImage = _nextButton.GetComponent<Image>();
            _endImage.sprite = _endSprite;
        }
        else//テキストが終わったとき
        {
            _nextButton.SetActive(false);
            _nameLabel.text = "";
            _messageText.text = "";
            _mainUI.SetActive(true);
            fpc.GetComponent<FirstPersonController>().isCameraMove = true;
            fpc.GetComponent<FirstPersonController>().enableHeadBob = true;
            fpc.GetComponent<FirstPersonController>().playerCanMove = true;
            Debug.Log(_currentPage + 1 + "/" + _messages.Count);
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
        _index = index;

        _nameLabel.enabled = true;
        _messageText.enabled = true;
        _mainUI.SetActive(false);
        //_zombie.SetActive(false);
        fpc.GetComponent<FirstPersonController>().isCameraMove = false;
        fpc.GetComponent<FirstPersonController>().enableHeadBob = false;
        fpc.GetComponent<FirstPersonController>().playerCanMove = false;
        _currentPage++;
        if (_first)
        {
            _first = false;
            _messages.Add("");
        }
        switch (index)//管理引数に対応したメッセージを格納
        {
            case 0://スタート時のメッセージ
                _nameLabel.text = "???";
                _messages.Add("あなた、この学校の教師よね？");
                _messages.Add("ピアノを弾きたいんだけど、\n鍵が見つからないの...");
                _messages.Add("教師なら鍵の場所わかるでしょ？\nお願い、探して！！");

                break;

            case 1://ピアノのカギ取得時のメッセージ
                _nameLabel.text = "???";
                _messages.Add("まずい、良くないものが来るわ。\nどこかに隠れないと...");

                break;

            case 2://ゾンビを回避した時のメッセージ
                _nameLabel.text = "???";
                _messages.Add("...行ったみたいね。\nあれはこの場所をうろついているの。気を付けて");

                break;

            case 3://ピアノが開いた時のメッセージ
                _nameLabel.text = "???";
                _messages.Add("やった、これであの時の曲が弾けるわ！...多分、あなたも知っている曲よ");
                _messages.Add("次は1階にある美術室に行きたいんだけど、ついてきてくれない？");
                _saveDataManager.WriteSaveData(Story.musicRoom, true, true);

                break;

            case 4://無限ループ発覚時のメッセージ
                _nameLabel.text = "???";
                _messages.Add("...ねえ、なんだか同じ場所を回っている気がするのだけど");
                _messages.Add("美術室に行きたいのに...。どうして？");
                _messages.Add("ごめんなさい、なんだか忘れているものがある気がするの。\n進めないのはそのせい？");
                _messages.Add("2年生の頃に絵画で最優秀賞を取ったんだけど、もしかしてそれが必要なのかしら");

                break;

            case 5://ゾンビ徘徊ポイントの手前に到着時のメッセージ
                _nameLabel.text = "???";
                _messages.Add("気を付けて。またさっきの良くないものがいるわ");
                _messages.Add("ぐるぐる回っているのかしら。見つからないように隠れて行きましょう");

                break;

            case 6://絵画取得時
                _nameLabel.text = "???";
                _messages.Add("これよこれ。私が描いた絵画なの。なかなか上手だと思わない？");
                _messages.Add("でもまだ修正したい箇所があったのよね...");
                _messages.Add("せっかくだから美術室で修正するのを手伝ってほしいの。\n私にはもうできないから...。");
                break;

            case 7://クリア時
                _nameLabel.text = "理音";
                _messages.Add("センキュー!お疲れぃばいばいー");
                break;
        }
        StartCoroutine(_TextChange());
    }
}
