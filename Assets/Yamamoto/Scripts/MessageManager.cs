using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageManager : MonoBehaviour
{
    public Text _messageText;//���b�Z�[�W�̃e�L�X�g�\���p
    public Text _nameLabel;//�b�҂̖��O�\���p
    public GameObject _nextButton;
    public GameObject _mainUI;
    public GameObject _enemyMove;
    public FirstPersonController _firstPersonController;
    int _textPage;//���b�Z�[�W�̃y�[�W��
    int _currentPage=0;//���݂̃y�[�W
    int _messageIndex;//���b�Z�[�W�Ǘ��p����
    List<string> _messages;//���b�Z�[�W�̃y�[�W
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
        if (_messageText.text == _messages[_currentPage])//1�y�[�W���̃e�L�X�g�̏o�͂��I������Ƃ�
        {
            // �}�E�X�J�[�\����\����Ԃɂ���
            Cursor.visible = true;

            // �}�E�X�J�[�\���̃��b�N����������
            Cursor.lockState = CursorLockMode.None;
            _nextButton.SetActive(true);
            if (_currentPage == (_messages.Count - 1))//���̃y�[�W���Ō�̎�
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

        if (_currentPage < _messages.Count - 1)//�e�L�X�g���c���Ă���Ƃ�
        {
            _currentPage++;
            _messageText.text = "";
            Debug.Log(_currentPage+1+"/"+_messages.Count);
            StartCoroutine(_TextChange());
        }
        else//�e�L�X�g���I������Ƃ�
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
    IEnumerator _TextChange()//�e�L�X�g����p�̃R���[�`��
    {
        foreach (char x in _messages[_currentPage].ToCharArray())//
        {
            _messageText.text += x;
            //���ʉ�������Ȃ炱��
            yield return new WaitForSeconds(0.1f);
           
        }
       
    }
    IEnumerator _WaitAMinute()
    {
        yield return new WaitForSeconds(1);
    }
    void _MessageStorage(int index)//���b�Z�[�W�Ǘ��p�̊֐�
    {
        _nameLabel.enabled = true;
        _messageText.enabled = true;
        _mainUI.SetActive(false);
        _firstPersonController.playerCanMove = false;
        _enemyMove.SetActive(false);
        _firstPersonController.isCameraMove = false;
        switch (index)//�Ǘ������ɑΉ��������b�Z�[�W���i�[
        {
            case 0://�X�^�[�g���̃��b�Z�[�W
                _textPage = 1;
                _nameLabel.text = "�H��";
                _messages.Add("�s�A�m���e������...");
                Debug.Log("Page:"+_messages.Count);
                break;
            case 1:
                _textPage = 2;
                _currentPage++;
                _nameLabel.text = "����";
                _messages.Add("(��ꂽ�Ȃ�...)");
                _messages.Add("(��������������...)");
                Debug.Log("Page:" + _messages.Count);
                break;
        }
        StartCoroutine(_TextChange());
    }
}
