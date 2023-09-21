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
        // セーブデータを保存しているオブジェクトを取得
        _saveDataListO = GameObject.FindWithTag("SaveDataList");
        _saveDataList = _saveDataListO.GetComponent<SaveDataList>();

        // セーブデータの存在確認をして存在すれば音楽室のクリアフラグを取得
        bool isExistData = _saveDataList._loadStory != Story.another;

        if (isExistData)
        {
            _isMusicRoomCleared = _saveDataList._saveData[(int)_saveDataList._loadStory - 1]._isMusicRoomClear;
        }
    }
}
