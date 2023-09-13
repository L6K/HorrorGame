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
    const int _SYNOPSIS_PAGE = 4;//あらすじのページ数
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



        //要素一つで一ページ分(一行は最大でも全角26文字)
        _textes[0] = "テスト\nテステス\nテーステス";//1ページ目

        _textes[1] = "これはテスト用の文章です。\n実装までに差し替えてね\n頑張ってね";//2ページ目

        _textes[2] = "あ\nい\nう\nえ\nお";//3ページ目

        _textes[3] = "1234567890\n0987654321";//4ページ目


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
