using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDataManager : MonoBehaviour
{
    private List<ItemData> _belongingList;
    private ItemUIManager _itemUIManager;
    private SaveData[] _saveDataList;
    private Story _clearStory;
    private MessageManager _messageManager;

    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _zombie;
    [SerializeField] private GameObject _belongings;
    [SerializeField] private GameObject _itemPanel;
    [SerializeField] private GameObject _messageManagerO;
    [SerializeField] private GameObject _infinitedStear;

    [SerializeField] private GameObject _saveDataListO;

    void Start()
    {
        // 所持品リストのアドレスを取得
        _belongingList = _belongings.GetComponent<BelongingList>()._belongings;

        // ItemUIManagerを取得
        _itemUIManager = _itemPanel.GetComponent<ItemUIManager>();

        // セーブデータを保存しているオブジェクトを取得
        _saveDataListO = GameObject.FindWithTag("SaveDataList");
        _saveDataList = _saveDataListO.GetComponent<SaveDataList>()._saveData;
        _clearStory = _saveDataListO.GetComponent<SaveDataList>()._loadStory;

        // コンポーネントを取得
        _messageManager = _messageManagerO.GetComponent<MessageManager>();

        // 読み込むデータがあるか判定して、あればセーブデータを読み込む
        bool isNeedLoad = _clearStory != Story.another;

        Debug.Log("clearStory：" + _clearStory);

        if (isNeedLoad)
        {
            LoadSaveData();
        }
        else
        {
            // 読み込むデータがなければ初回メッセージ送りを起動する
            _messageManager.MessageManage(0);
        }
    }

    /// <summary>
    /// セーブデータを読み込むメソッド
    /// </summary>
    public void LoadSaveData()
    {
        int loadNum = (int)_clearStory - 1;
        SaveData loadData = _saveDataList[loadNum];

        // プレイヤーの位置を設定
        _player.transform.position = loadData._playerPosition;
        _player.transform.rotation = loadData._playerRotate;

        // ゾンビの位置を設定
        _zombie.transform.position = loadData._zombiePosition;
        _zombie.transform.rotation = loadData._zombieRotate;

        // 所持品リストを書き換えてUIを更新
        _belongingList = loadData._belongings;
        _itemUIManager.UpdateDisplayItemList();
        _itemUIManager.LoadItemPanel();

        // 無限階段フラグが立っていれば無限階段を起動
        if (loadData._isInfinitedStair)
        {
            _infinitedStear.SetActive(true);
        }
    }

    /// <summary>
    /// セーブデータを書き込むメソッド(怪異解決時に呼び出し)
    /// </summary>
    public void WriteSaveData(Story clearStory, bool isMusicRoomClear, bool isInfinitedStear)
    {
        int writeNum = (int)clearStory - 1;
        SaveData writeData = new SaveData();

        // プレイヤーの位置を保存
        writeData._playerPosition = _player.transform.position;
        writeData._playerRotate = _player.transform.rotation;

        // ゾンビの位置を保存
        writeData._zombiePosition = _zombie.transform.position;
        writeData._zombieRotate = _zombie.transform.rotation;

        // 所持品リストを保存
        writeData._belongings = _belongingList;

        // フラグ情報を保存
        writeData._isMusicRoomClear = isMusicRoomClear;
        writeData._isInfinitedStair = isInfinitedStear;

        // 最終セーブ地点を保存
        _saveDataListO.GetComponent<SaveDataList>()._loadStory = clearStory;

        // セーブデータリストに格納
        _saveDataList[writeNum] = writeData;
    }
}
