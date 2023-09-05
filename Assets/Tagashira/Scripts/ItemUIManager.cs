using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.UI;

public class ItemUIManager : MonoBehaviour
{
    private const int NUMBER_OF_ITEM_DISPLAY = 7;
    private const int UNSELECTED_ITEM = -1;

    private ItemDAO _itemDAO;
    private List<ItemData> _itemList;
    private List<ItemData> _displayItemList;
    private int _nowDisplayPage;
    private int _maxDisplayPage;
    private bool _isCanPrevPage;
    private bool _isCanNextPage;
    private ItemData _nothing;
    private Text _displayItemName;
    private bool _isFadeout;

    [SerializeField] private Story _storyOfNothing;
    [SerializeField] private int _indexOfNothing;
    
    [SerializeField] private GameObject _itemDatabase;
    [SerializeField] private GameObject _belongings;

    [SerializeField] private GameObject _prevItemBotton;
    [SerializeField] private GameObject _nextItemBotton;
    [SerializeField] private GameObject[] _itemDisplayers;
    [SerializeField] private GameObject _itemNameText;
    [SerializeField] private float _timeOfDisplayItemName;
    [SerializeField] private float _fadeoutSpeed;

    public int _selectItemPanel;

    void Start()
    {
        // �R���|�[�l���g���擾
        _itemDAO = _itemDatabase.GetComponent<ItemDAO>();
        _displayItemName = _itemNameText.GetComponent<Text>();

        // �A�C�e�����͕K�v�Ȏ������\������̂Ŕ�\���ɂ���
        _itemNameText.SetActive(false);

        // �����A�C�e���̃��X�g���擾
        _itemList = _belongings.GetComponent<BelongingList>()._belongings;

        // �\������A�C�e���̃��X�g���쐬
        _displayItemList = new List<ItemData>();

        _nowDisplayPage = 1;

        // �ǂ̃A�C�e�����I������Ă��邩
        _selectItemPanel = UNSELECTED_ITEM;

        // �ő�y�[�W�����v�Z(�����A�C�e�����ɂ��ϓ�)
        _maxDisplayPage = _itemList.Count / NUMBER_OF_ITEM_DISPLAY;
        bool isDivisible = _itemList.Count % NUMBER_OF_ITEM_DISPLAY == 0;
        bool isNoItem = _itemList.Count == 0;

        if (!isDivisible || isNoItem)
        {
            _maxDisplayPage++;
        }

        // �A�C�e���������Ă��Ȃ��}�X�p�̃A�C�e��(nothing)�̃C���X�^���X���擾
        _nothing = _itemDAO.GetItemData(_storyOfNothing, _indexOfNothing);

        // UI�ɃA�C�e����\��
        UpdateDisplayItemList();

        LoadItemPanel();
    }

    // Update is called once per frame
    void Update()
    {
        // �y�[�W�؂�ւ��{�^���̕\����\���؂�ւ�
        // �O�̃y�[�W�����邩����
        if (_nowDisplayPage > 1)
        {
            _isCanPrevPage = true;
        }
        else
        {
            _isCanPrevPage = false;
        }
        // ���̃y�[�W�����邩����
        if (_nowDisplayPage < _maxDisplayPage)
        {
            _isCanNextPage = true;
        }
        else
        {
            _isCanNextPage = false;
        }

        // �O�̃y�[�W(��)
        if (_isCanPrevPage)
        {
            _prevItemBotton.SetActive(true);
        }
        else
        {
            _prevItemBotton.SetActive(false);
        }

        // ���̃y�[�W(��)
        if (_isCanNextPage)
        {
            _nextItemBotton.SetActive(true);
        }
        else
        {
            _nextItemBotton.SetActive(false);
        }

        Color textColor = _displayItemName.color;

        // �A�C�e�����̕\���e�L�X�g���t�F�[�h�A�E�g������
        if (_isFadeout)
        {
            if (_displayItemName.color.a - _fadeoutSpeed <= 0)
            {
                textColor.a = 0;
                _displayItemName.color = textColor;

                _itemNameText.SetActive(false);
                textColor.a = 255;
                _displayItemName.color = textColor;

                _isFadeout = false;
            }
            else
            {
                textColor.a -= _fadeoutSpeed;
                _displayItemName.color = textColor;
            }
        }
    }

    /// <summary>
    /// _displayItemList���X�V���郁�\�b�h
    /// </summary>
    public void UpdateDisplayItemList()
    {
        // _displayItemList���N���A
        _displayItemList.Clear();

        // _itemList�̉��Ԗڂ��牽�Ԗڂ܂ł̃A�C�e����\�����邩�v�Z
        int firstItem = (_nowDisplayPage - 1) * NUMBER_OF_ITEM_DISPLAY;
        int lastItem = firstItem + NUMBER_OF_ITEM_DISPLAY;

        // �A�C�e���������}�X�̐����v�Z(nothing������)
        int numberOfBrank = 0;

        if (lastItem > _itemList.Count)
        {
            numberOfBrank = lastItem - _itemList.Count;
        }

        // _displayItemLIst�ɕ\������A�C�e�����i�[
        for (int i = firstItem; i < lastItem; i++)
        {
            if (i < _itemList.Count)
            {
                _displayItemList.Add(_itemList[i]);
            }
            else
            {
                // �󗓂�nothing���i�[
                _displayItemList.Add(_nothing);
            }
        }
    }

    /// <summary>
    /// �A�C�e����UI��ǂݍ��ރ��\�b�h(�X�V�ɂ��g��)
    /// </summary>
    public void LoadItemPanel()
    {
        for (int i = 0; i < NUMBER_OF_ITEM_DISPLAY; i++)
        {
            // ItemDisplayer���擾���A�C�e���p�l���̏��𔽉f������
            ItemDisplayer displayer = _itemDisplayers[i].GetComponent<ItemDisplayer>();

            bool isSelected = _selectItemPanel == i;
            displayer.ItemDisplay(_displayItemList[i], isSelected);
        }
    }

    /// <summary>
    /// �A�C�e���̑O�̃y�[�W��\�����郁�\�b�h
    /// </summary>
    public void PrevItemPage()
    {
        // �\���y�[�W��1�O�ɖ߂�
        _nowDisplayPage--;

        // �I���A�C�e�������Z�b�g
        _selectItemPanel = UNSELECTED_ITEM;

        // UI�ɔ��f
        UpdateDisplayItemList();
        LoadItemPanel();
    }

    /// <summary>
    /// �A�C�e���̎��̃y�[�W��\�����郁�\�b�h
    /// </summary>
    public void NextItemPage()
    {
        // �\���y�[�W�����ɐi�߂�
        _nowDisplayPage++;

        // �I���A�C�e�������Z�b�g
        _selectItemPanel = UNSELECTED_ITEM;

        // UI�ɔ��f
        UpdateDisplayItemList();
        LoadItemPanel();
    }

    /// <summary>
    /// UI����A�C�e����I�����ꂽ���̏������s�����\�b�h
    /// </summary>
    /// <param name="numberOfPanel"></param>
    public void SelectItem(int numberOfPanel)
    {
        // �I�����ꂽ�̂�nothing�Ȃ珈�����Ȃ�
        bool isNothing = _displayItemList[numberOfPanel]._itemName == _nothing._itemName;

        if (isNothing)
        {
            return;
        }

        // ���ݑI������Ă���A�C�e�����ĂёI�����ꂽ�牽���I�����Ă��Ȃ���Ԃɖ߂�
        // �ʂ̃A�C�e�����I�����ꂽ�ꍇ�͌��ݑI������Ă���A�C�e����ύX
        if (_selectItemPanel == numberOfPanel)
        {
            _selectItemPanel = UNSELECTED_ITEM;
        }
        else
        {
            _selectItemPanel = numberOfPanel;

            // �A�C�e�����\���̃e�L�X�g��I�����ꂽ�A�C�e���ɕύX
            _displayItemName.text = _displayItemList[numberOfPanel]._itemName;
            _itemNameText.SetActive(true);

            // �C���X�y�N�^�[�Ŏw�肳�ꂽ�b���\�����A�o�߂�����񊈐��ɖ߂�
            Invoke("FadeoutText", _timeOfDisplayItemName);
        }

        // UI�ɔ��f
        UpdateDisplayItemList();
        LoadItemPanel();
    }

    void FadeoutText()
    {
        _isFadeout = true;
    }

    // �o���F�A�C�e���I�������ǂ����ɓn�����\�b�h�͕ʂō���ă��\�b�h�Ăяo���ŏ�������
}
