using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleController : MonoBehaviour
{
    public Text _synopsisText;//あらすじのテキスト表示用
    public Image[] _synopsisImages;//静止画の表示用
    public GameObject _startButton;
    public GameObject _nextButton;
    const int _SYNOPSIS_PAGE = 3;//あらすじのページ数
    int _currentPage;
    int _currentImage;
    string[] _textes = new string[_SYNOPSIS_PAGE];//あらすじのページ


    // Start is called before the first frame update
    void Start()
    {
        _nextButton.SetActive(false);

        foreach (Image image in _synopsisImages)//全画像を非表示
        {
            image.enabled = false;
        }



        //要素一つで一ページ分(一行は最大でも全角26文字、行数は10行)
        //1ページ目
        _textes[0] 
            = "ここは松風高等学校、\n"
            + "どうやらこの学校はもうすぐ廃校になるらしい。\n"
            + "廃校になる前にこの学校の七不思議を解くべく、\n"
            + "みんなが帰ったこの学校を調査しようと思う。";

        //2ページ目
        _textes[1] 
            = "この学校を調べるために職員室からマスターキーを取る。\n"
            + "さて、どんな噂があっただろうか…\n"
            + "そうだ、こんなのがあった。\n"
            + "『誰もいないはずの音楽室から聞こえる鼻歌』...\n"
            + "という話だ。\n"
            + "確かその怪異が起きる音楽室は2階だな...";

        //3ページ目
        _textes[2]
            = "夜の学校は恐ろしいくらい静まり返っている。\n"
            + "昼の高校はあんなにも楽しそうな声が聞こえるのに...\n";


        this._currentPage = 0;
        this._currentImage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (_synopsisText.text == _textes[_currentPage])//1ページ内のテキストの出力が終わったとき
        {
            _nextButton.SetActive(true);
            if (_currentPage == (_textes.Length - 1))//そのページが最後の時
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
    public void OnStartButtonClicked()
    {
        _synopsisImages[_currentImage].enabled = true;
        _startButton.SetActive(false);
        StartCoroutine(_TextChange());

    }
    void _LoadScene()
    {
        SceneManager.LoadScene("Main");
    }
    public void OnNextButtonClicked()
    {
        if (_currentImage < _synopsisImages.Length - 1)//静止画のページ処理
        {
            _currentImage++;
            _synopsisImages[_currentImage].enabled = true;
            if (_currentImage != 0)
            {
                _synopsisImages[_currentImage - 1].enabled = false;
            }
        }
        if (_currentPage < _textes.Length - 1)//テキストのページ処理
        {
            _currentPage++;
            _synopsisText.text = "";
            StartCoroutine(_TextChange());
        }
        else
        {
            _LoadScene();
        }

    }
    IEnumerator _TextChange()//テキスト送り用のコルーチン
    {
        foreach (char x in _textes[_currentPage].ToCharArray())
        {
            _synopsisText.text += x;
            //効果音を入れるならここ
            yield return new WaitForSeconds(0.1f);
        }
    }
}
