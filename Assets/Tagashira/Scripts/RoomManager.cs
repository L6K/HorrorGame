using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomManager : MonoBehaviour
{
    private Text _roomText;
    private Text _floorText;

    [SerializeField] private GameObject _roomUI;
    [SerializeField] private string _initialPlacement;
    [SerializeField] private GameObject _floorUI;
    [SerializeField] private int _initialFloor;

    public string _roomName;
    public string _numOfFloor;

    void Start()
    {
        // コンポーネントを取得
        _roomText = _roomUI.GetComponent<Text>();
        _floorText = _floorUI.GetComponent<Text>();

        // 部屋名を初期配置に変更
        _roomName = _initialPlacement;
        _numOfFloor = _initialFloor + "F";
        DisplayRoomName();
        DisplayNumOfFloor();
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

    /// <summary>
    /// 階数を変更しUI表示に反映
    /// </summary>
    public void SetNumOfFloor(string floor)
    {
        _numOfFloor = floor;
        DisplayNumOfFloor();
    }

    void DisplayNumOfFloor()
    {
        _floorText.text = _numOfFloor;
    }
}
