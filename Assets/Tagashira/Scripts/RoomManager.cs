using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomManager : MonoBehaviour
{
    private Text _roomText;

    [SerializeField] private GameObject _roomUI;
    [SerializeField] private string _initialPlacement;

    public string _roomName;

    void Start()
    {
        // コンポーネントを取得
        _roomText = _roomUI.GetComponent<Text>();

        // 部屋名を初期配置に変更
        _roomName = _initialPlacement;
        DisplayRoomName();
    }

    /// <summary>
    /// 部屋名を変更しUI表示に反映
    /// </summary>
    /// <param name="roomName"></param>
    public void SetRoomName(string roomName)
    {
        _roomName = roomName;
        DisplayRoomName();
    }

    /// <summary>
    /// 部屋名のUI表示を反映
    /// </summary>
    void DisplayRoomName()
    {
        _roomText.text = _roomName;
    }
}
