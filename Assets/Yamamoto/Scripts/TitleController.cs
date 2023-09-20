using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleController : MonoBehaviour
{
    public Text _synopsisText;//���炷���̃e�L�X�g�\���p
    public Image[] _synopsisImages;//�Î~��̕\���p
    public GameObject _startButton;
    public GameObject _nextButton;
    const int _SYNOPSIS_PAGE = 3;//���炷���̃y�[�W��
    int _currentPage;
    int _currentImage;
    string[] _textes = new string[_SYNOPSIS_PAGE];//���炷���̃y�[�W


    // Start is called before the first frame update
    void Start()
    {
        _nextButton.SetActive(false);

        foreach (Image image in _synopsisImages)//�S�摜���\��
        {
            image.enabled = false;
        }



        //�v�f��ň�y�[�W��(��s�͍ő�ł��S�p26�����A�s����10�s)
        //1�y�[�W��
        _textes[0] 
            = "�����͏��������w�Z�A\n"
            + "�ǂ���炱�̊w�Z�͂��������p�Z�ɂȂ�炵���B\n"
            + "�p�Z�ɂȂ�O�ɂ��̊w�Z�̎��s�v�c�������ׂ��A\n"
            + "�݂�Ȃ��A�������̊w�Z�𒲍����悤�Ǝv���B";

        //2�y�[�W��
        _textes[1] 
            = "���̊w�Z�𒲂ׂ邽�߂ɐE��������}�X�^�[�L�[�����B\n"
            + "���āA�ǂ�ȉ\�����������낤���c\n"
            + "�������A����Ȃ̂��������B\n"
            + "�w�N�����Ȃ��͂��̉��y�����畷������@�́x...\n"
            + "�Ƃ����b���B\n"
            + "�m�����̉��ق��N���鉹�y����2�K����...";

        //3�y�[�W��
        _textes[2]
            = "��̊w�Z�͋��낵�����炢�Â܂�Ԃ��Ă���B\n"
            + "���̍��Z�͂���Ȃɂ��y�������Ȑ�����������̂�...\n";


        this._currentPage = 0;
        this._currentImage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (_synopsisText.text == _textes[_currentPage])//1�y�[�W���̃e�L�X�g�̏o�͂��I������Ƃ�
        {
            _nextButton.SetActive(true);
            if (_currentPage == (_textes.Length - 1))//���̃y�[�W���Ō�̎�
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
        if (_currentImage < _synopsisImages.Length - 1)//�Î~��̃y�[�W����
        {
            _currentImage++;
            _synopsisImages[_currentImage].enabled = true;
            if (_currentImage != 0)
            {
                _synopsisImages[_currentImage - 1].enabled = false;
            }
        }
        if (_currentPage < _textes.Length - 1)//�e�L�X�g�̃y�[�W����
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
    IEnumerator _TextChange()//�e�L�X�g����p�̃R���[�`��
    {
        foreach (char x in _textes[_currentPage].ToCharArray())
        {
            _synopsisText.text += x;
            //���ʉ�������Ȃ炱��
            yield return new WaitForSeconds(0.1f);
        }
    }
}
