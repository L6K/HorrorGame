using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageManager : MonoBehaviour
{
    public Text _messageText;//あらすじのテキスト表示用
    public GameObject _nextButton;
    const int _TEXT_PAGE = 3;//あらすじのページ数
    int _currentPage;
    //public GameObject;
    string[] _messages = new string[_TEXT_PAGE];//あらすじのページ
    // Start is called before the first frame update
    void Start()
    {
        _nextButton.SetActive(false);

        

            this._currentPage = 0;
            
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_messageText.text == _messages[_currentPage])//1ページ内のテキストの出力が終わったとき
        {
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
    public void OnStartButtonClicked()
    {
        
        //_startButton.SetActive(false);
        StartCoroutine(_TextChange());

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
            
        }

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
}
