using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private ItemDAO _itemDAO;
    private List<ItemData> _belongingList;
    private ItemUIManager _itemUIManager;

    [SerializeField] private GameObject _itemDatabase;
    [SerializeField] private GameObject _belongings;
    [SerializeField] private GameObject _itemPanel;

    [SerializeField] private ItemData _nowSelectedItem;

    void Start()
    {
        // �R���|�[�l���g���擾
        _itemDAO = _itemDatabase.GetComponent<ItemDAO>();
        _belongingList = _belongings.GetComponent<BelongingList>()._belongings;
        _itemUIManager = _itemPanel.GetComponent<ItemUIManager>();
    }

    /// <summary>
    /// �A�C�e�������̏������s�����\�b�h�B�����󂯎���ď����i���X�g�ɒǉ��AUI�ɔ��f����B
    /// </summary>
    /// <param name="whereUse"></param>
    /// <param name="Index"></param>
    public void ObtainItem(Story whereUse, int index)
    {
        // ���肵���A�C�e���̏����擾
        ItemData obtainItem = _itemDAO.GetItemData(whereUse, index);

        // �����i���X�g�ɒǉ�
        _belongingList.Add(obtainItem);

        // UI�ɔ��f
        _itemUIManager.CulcDisplayPage();
        _itemUIManager.UpdateDisplayItemList();
        _itemUIManager.LoadItemPanel();
    }

    /// <summary>
    /// �I�����ꂽ�A�C�e���̏����󂯎��t�B�[���h�ɕێ����郁�\�b�h
    /// </summary>
    /// <param name="selectedItem"></param>
    public void SetSelectedItem(ItemData selectedItem)
    {
        _nowSelectedItem = selectedItem;
    }

    /// <summary>
    /// �I�����ꂽ�A�C�e���̏���Ԃ����\�b�h
    /// </summary>
    /// <returns></returns>
    public ItemData GetSelectedItem()
    {
        return _nowSelectedItem;
    }

    /// <summary>
    /// �A�C�e���g�p�̍ۂ̃f�[�^�I�ȏ���(�����i���X�g�AUI�̍X�V)
    /// </summary>
    public void UseItem()
    {
        // �����i���X�g����A�C�e�����폜
        _belongingList.Remove(_nowSelectedItem);

        // UI�ɔ��f
        _itemUIManager.CulcDisplayPage();
        _itemUIManager.UpdateDisplayItemList();
        _itemUIManager.LoadItemPanel();
    }
}
