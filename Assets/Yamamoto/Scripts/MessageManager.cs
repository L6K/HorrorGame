using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageManager : MonoBehaviour
{
    public Text _messageText;//���b�Z�[�W�̃e�L�X�g�\���p
    public Text _nameLabel;//�b�҂̖��O�\���p
    public GameObject _nextButton;//���փ{�^��
    public GameObject _mainUI;//UI�֘A
    public GameObject fpc;//����
    public GameObject _zombie;//�]���r
    int _currentPage=0;//���݂̃y�[�W
    int _messageIndex;//���b�Z�[�W�Ǘ��p����
    List<string> _messages;//���b�Z�[�W�̃y�[�W
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
    }
   
    public void OnNextButtonClicked() //���փ{�^��������
    {
        if (_currentPage < _messages.Count - 1)//�e�L�X�g���c���Ă���Ƃ�
        {
            _currentPage++;
            _messageText.text = "";
            StartCoroutine(_TextChange());
        }
        else//�e�L�X�g���I������Ƃ�
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
    public void MessageManage(int index)//���b�Z�[�W�Ǘ��p�̊֐�
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
        switch (index)//�Ǘ������ɑΉ��������b�Z�[�W���i�[
        {
            case 0://�X�^�[�g���̃��b�Z�[�W
                _nameLabel.text = "???";
                _messages.Add("���Ȃ����̊w�Z�̋��t�H");
                _messages.Add("�s�A�m��e�������񂾂��ǁA\n����������Ȃ���...");
                _messages.Add("���Ȃ����t�Ȃ献�̏ꏊ�킩���ˁH\n���肢�A�T���āI�I");
                
                break;
            case 1://�s�A�m�̃J�M�擾���̃��b�Z�[�W
                _nameLabel.text = "???";
                _messages.Add("�܂����A�ǂ��Ȃ����̂������B\n�ǂ����ɉB��Ȃ���...");
                              
                break;
            case 2://�]���r������������̃��b�Z�[�W
                _nameLabel.text = "???";
                _messages.Add("�c�s�����݂����ˁB\n����͂��̏ꏊ��������Ă���́B�C��t����");

                break;
            case 3://�s�A�m���J�������̃��b�Z�[�W
                _nameLabel.text = "???";
                _messages.Add("�������I����ł��̎��̋Ȃ��e�����I");
                _messages.Add("�˂����͔��p���ɍs�������񂾂��ǁA���Ă��Ă���Ȃ��H");
                PlayerPrefs.SetString("_isMusicClear", "Clear");

                break;
        }
        StartCoroutine(_TextChange());
    }
}
