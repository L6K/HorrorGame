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
        // �R���|�[�l���g���擾
        _roomText = _roomUI.GetComponent<Text>();

        // �������������z�u�ɕύX
        _roomName = _initialPlacement;
        DisplayRoomName();
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
}
