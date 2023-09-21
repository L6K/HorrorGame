using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicRoomClearDitecter : MonoBehaviour
{
    private SaveDataList _saveDataList;

    [SerializeField] private GameObject _saveDataListO;

    public bool _isMusicRoomCleared;

    void Start()
    {
        // �Z�[�u�f�[�^��ۑ����Ă���I�u�W�F�N�g���擾
        _saveDataListO = GameObject.FindWithTag("SaveDataList");
        _saveDataList = _saveDataListO.GetComponent<SaveDataList>();

        // �Z�[�u�f�[�^�̑��݊m�F�����đ��݂���Ή��y���̃N���A�t���O���擾
        bool isExistData = _saveDataList._loadStory != Story.another;

        if (isExistData)
        {
            _isMusicRoomCleared = _saveDataList._saveData[(int)_saveDataList._loadStory - 1]._isMusicRoomClear;
        }
    }
}
