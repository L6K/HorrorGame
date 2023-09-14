using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageManager : MonoBehaviour
{
    public Text _messageText;//���炷���̃e�L�X�g�\���p
    public GameObject _nextButton;
    const int _TEXT_PAGE = 3;//���炷���̃y�[�W��
    int _currentPage;
    //public GameObject;
    string[] _messages = new string[_TEXT_PAGE];//���炷���̃y�[�W
    // Start is called before the first frame update
    void Start()
    {
        _nextButton.SetActive(false);

        

            this._currentPage = 0;
            
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_messageText.text == _messages[_currentPage])//1�y�[�W���̃e�L�X�g�̏o�͂��I������Ƃ�
        {
            _nextButton.SetActive(true);
            if (_currentPage == (_messages.Length - 1))//���̃y�[�W���Ō�̎�
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
        
        if (_currentPage < _messages.Length - 1)//�e�L�X�g�̃y�[�W����
        {
            _currentPage++;
            _messageText.text = "";
            StartCoroutine(_TextChange());
        }
        else
        {
            
        }

    }
    IEnumerator _TextChange()//�e�L�X�g����p�̃R���[�`��
    {
        foreach (char x in _messages[_currentPage].ToCharArray())
        {
            _messageText.text += x;
            //���ʉ�������Ȃ炱��
            yield return new WaitForSeconds(0.1f);
        }
    }
}
