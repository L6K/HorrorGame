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
    int _currentPage = 0;//���݂̃y�[�W
    List<string> _messages;//���b�Z�[�W�̃y�[�W
    private bool _first = true;
    private int _index;

    // �Z�[�u�f�[�^�p�t�B�[���h
    [SerializeField] private GameObject _saveDataManagerO;
    private SaveDataManager _saveDataManager;

    // Start is called before the first frame update
    void Start()
    {
        _nextButton.SetActive(false);
        _nameLabel.enabled = false;
        _messageText.enabled = false;
        _messages = new List<string>();

        // �Z�[�u�f�[�^�p�R���|�[�l���g���擾
        _saveDataManager = _saveDataManagerO.GetComponent<SaveDataManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_messages.Count!=0)
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
    }

    public void OnNextButtonClicked() //���փ{�^��������
    {
        if (_currentPage < _messages.Count - 1)//�e�L�X�g���c���Ă���Ƃ�
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
        else//�e�L�X�g���I������Ƃ�
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
        _index = index;

        _nameLabel.enabled = true;
        _messageText.enabled = true;
        _mainUI.SetActive(false);
        _zombie.SetActive(false);
        fpc.GetComponent<FirstPersonController>().isCameraMove = false;
        fpc.GetComponent<FirstPersonController>().enableHeadBob = false;
        fpc.GetComponent<FirstPersonController>().playerCanMove = false;
        _currentPage++;
        if (_first)
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
                _messages.Add("�˂�����1�K�ɂ�����p���ɍs�������񂾂��ǁA���Ă��Ă���Ȃ��H");
                _saveDataManager.WriteSaveData(Story.musicRoom, true);

                break;

            case 4://�������[�v���o���̃��b�Z�[�W
                _nameLabel.text = "???";
                _messages.Add("�c�˂��A���ꓯ���ꏊ������Ă��Ȃ��H");
                _messages.Add("���p���ɍs�������̂Ɂc�B�ǂ����āH");
                _messages.Add("���߂�Ȃ����A�Ȃ񂾂��Y��Ă�����̂�����C������́B\n���ꂪ�����ƍs���Ă͂����Ȃ��̂�����");
                _messages.Add("��2�N���̍��ɊG��ōŗD�G�܂�������񂾂��ǁA���ꂪ�K�v�Ȃ̂�����B");

                break;

            case 5://�]���r�p�j�|�C���g�̎�O�ɓ������̃��b�Z�[�W
                _nameLabel.text = "???";
                _messages.Add("�C��t���āB�܂��������̗ǂ��Ȃ����̂������");
                _messages.Add("���邮�����Ă���̂�����B������Ȃ��悤�ɉB��čs���܂��傤");

                break;

            case 6://�G��擾��
                _nameLabel.text = "???";
                _messages.Add("����悱��B�����`�����G��Ȃ́B��肢�ł���H");
                _messages.Add("�ł��܂��C���������ӏ��������...");
                _messages.Add("���p���ŏC�����܂���");
                break;

            case 7://�N���A��
                _nameLabel.text = "����";
                _messages.Add("�Z���L���[!����ꂡ�΂��΂��[");
                break;
        }
        StartCoroutine(_TextChange());
    }
}
