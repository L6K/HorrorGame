using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDataManager : MonoBehaviour
{
    private List<ItemData> _belongingList;
    private ItemUIManager _itemUIManager;
    private SaveData[] _saveDataList;
    private Story _clearStory;

    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _zombie;
    [SerializeField] private GameObject _belongings;
    [SerializeField] private GameObject _itemPanel;

    [SerializeField] private GameObject _saveDataListO;

    void Start()
    {
        // �����i���X�g�̃A�h���X���擾
        _belongingList = _belongings.GetComponent<BelongingList>()._belongings;

        // ItemUIManager���擾
        _itemUIManager = _itemPanel.GetComponent<ItemUIManager>();

        // �Z�[�u�f�[�^��ۑ����Ă���I�u�W�F�N�g���擾(�f�o�b�O�p)
        _saveDataListO = GameObject.FindWithTag("SaveDataList");
        _saveDataList = _saveDataListO.GetComponent<SaveDataList>()._saveData;
        _clearStory = _saveDataListO.GetComponent<SaveDataList>()._loadStory;

        // �ǂݍ��ރf�[�^�����邩���肵�āA����΃Z�[�u�f�[�^��ǂݍ���
        bool isNeedLoad = _clearStory != Story.another;
        if (isNeedLoad)
        {
            LoadSaveData();
        }
    }

    /// <summary>
    /// �Z�[�u�f�[�^��ǂݍ��ރ��\�b�h
    /// </summary>
    public void LoadSaveData()
    {
        int loadNum = (int)_clearStory - 1;
        SaveData loadData = _saveDataList[loadNum];

        // �v���C���[�̈ʒu��ݒ�
        _player.transform.position = loadData._playerPosition.position;
        _player.transform.rotation = loadData._playerPosition.rotation;

        // �]���r�̈ʒu��ݒ�
        _zombie.transform.position = loadData._zonbiePosition.position;
        _zombie.transform.rotation = loadData._zonbiePosition.rotation;

        // �����i���X�g������������UI���X�V
        _belongingList = loadData._belongings;
        _itemUIManager.UpdateDisplayItemList();
        _itemUIManager.LoadItemPanel();
    }

    /// <summary>
    /// �Z�[�u�f�[�^���������ރ��\�b�h(���ى������ɌĂяo��)
    /// </summary>
    public void WriteSaveData(Story clearStory)
    {
        int writeNum = (int)clearStory - 1;
        SaveData writeData = _saveDataList[writeNum];

        // �v���C���[�̈ʒu��ۑ�
        writeData._playerPosition = _player.transform;

        // �]���r�̈ʒu��ۑ�
        writeData._zonbiePosition = _zombie.transform;

        // �����i���X�g��ۑ�
        writeData._belongings = _belongingList;

        // �ŏI�Z�[�u�n�_��ۑ�
        _saveDataListO.GetComponent<SaveDataList>()._loadStory = clearStory;
    }
}
