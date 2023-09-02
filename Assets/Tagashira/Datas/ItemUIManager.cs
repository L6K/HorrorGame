using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

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

    [SerializeField] private Story _storyOfNothing;
    [SerializeField] private int _indexOfNothing;
    
    [SerializeField] private GameObject _itemDatabase;
    [SerializeField] private GameObject _belongings;

    [SerializeField] private GameObject _prevItemBotton;
    [SerializeField] private GameObject _nextItemBotton;
    [SerializeField] private GameObject[] _itemDisplayers;

    public int _selectItemPanel;

    void Start()
    {
        // �R���|�[�l���g���擾
        _itemDAO = _itemDatabase.GetComponent<ItemDAO>();

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
        if (_maxDisplayPage == 1)
        {
            _isCanNextPage = false;
            _isCanPrevPage = false;
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
            if (i < NUMBER_OF_ITEM_DISPLAY - numberOfBrank)
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
}
