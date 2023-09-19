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
    public GameObject _triggerKey;
    public GameObject _triggerClear;
    public GameObject _triggerOpen;
    public GameObject _clearZ;
    public bool _isEvent;
    public bool _isKeyGet;
    public bool _clear;
    public bool _isPianoOpen;
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
        _isEvent = false;
        
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
        if(_isEvent)
        {
            _EventManager();
            _isEvent = false;
        }
        ;
        if (_clearZ.GetComponent<GameOver>()._clear) //���b�J�[�Ń]���r���瓦���ꂽ�Ƃ�
        {
            _isEvent = true;
            _clearZ.GetComponent<GameOver>()._clear = false;
        }
        
        
    }
   
    public void OnNextButtonClicked()
    {
        Debug.Log("A");
        if (_currentPage < _messages.Count - 1)//�e�L�X�g���c���Ă���Ƃ�
        {
            Debug.Log("X");
            _currentPage++;
            _messageText.text = "";
            Debug.Log(_currentPage+1+"/"+_messages.Count);
            StartCoroutine(_TextChange());
        }
        else//�e�L�X�g���I������Ƃ�
        {
            Debug.Log("Y");
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
        Debug.Log("Z");
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
    void _EventManager()
    {
        if(_isKeyGet)
        {
            _messageIndex = 1;
            _MessageStorage(_messageIndex);
            _isKeyGet = false;
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
    void _MessageStorage(int index)//���b�Z�[�W�Ǘ��p�̊֐�
    {
        _nameLabel.enabled = true;
        _messageText.enabled = true;
        _mainUI.SetActive(false);
        _firstPersonController.playerCanMove = false;
        _enemyMove.SetActive(false);
        _firstPersonController.isCameraMove = false;
        _firstPersonController.enableHeadBob = false;
        switch (index)//�Ǘ������ɑΉ��������b�Z�[�W���i�[
        {
            case 0://�X�^�[�g���̃��b�Z�[�W
                
                _nameLabel.text = "???";
                _messages.Add("���Ȃ����̊w�Z�̋��t�H");
                _messages.Add("�s�A�m��e�������񂾂��ǁA\n����������Ȃ���...");
                _messages.Add("���Ȃ����t�Ȃ献�̏ꏊ�킩���ˁH\n���肢�A�T���āI�I");
                
                break;
            case 1://�s�A�m�̃J�M�擾���̃��b�Z�[�W
                
                _currentPage++;
                _nameLabel.text = "???";
                _messages.Add("�܂����A�ǂ��Ȃ����̂������B\n�ǂ����ɉB��Ȃ���...");
                
               
                break;
            case 2://�]���r������������̃��b�Z�[�W

                _currentPage++;
                _nameLabel.text = "???";
                _messages.Add("�c�s�����݂����ˁB\n����͂��̏ꏊ��������Ă���́B�C��t����");


                break;
            case 3://�s�A�m���J�������̃��b�Z�[�W

                _currentPage++;
                _nameLabel.text = "???";
                _messages.Add("�������I����ł��̎��̋Ȃ��e�����I");
                _messages.Add("�˂����͔��p���ɍs�������񂾂��ǁA���Ă��Ă���Ȃ��H");

                break;
        }
        StartCoroutine(_TextChange());
    }

}
