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
        // �R���|�[�l���g���擾
        _roomText = _roomUI.GetComponent<Text>();
        _floorText = _floorUI.GetComponent<Text>();

        // �������������z�u�ɕύX
        _roomName = _initialPlacement;
        _numOfFloor = _initialFloor + "F";
        DisplayRoomName();
        DisplayNumOfFloor();
    }

    /// <summary>
    /// ��������ύX��UI�\���ɔ��f
    /// </summary>
    /// <param name="roomName"></param>
    public void SetRoomName(string roomName)
    {
        _roomName = roomName;
        DisplayRoomName();
    }

    /// <summary>
    /// ��������UI�\���𔽉f
    /// </summary>
    void DisplayRoomName()
    {
        _roomText.text = _roomName;
    }

    /// <summary>
    /// �K����ύX��UI�\���ɔ��f
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
