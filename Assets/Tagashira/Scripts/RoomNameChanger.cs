using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNameChanger : MonoBehaviour
{
    private RoomManager _roomManager;

    [SerializeField] private string _northEastRoom;
    [SerializeField] private string _southWestRoom;
    [SerializeField] private GameObject _roomManagerO;
    [SerializeField] private bool _isEastWest;

    // Start is called before the first frame update
    void Start()
    {
        // �R���|�[�l���g���擾
        _roomManager = _roomManagerO.GetComponent<RoomManager>();
    }

    /// <summary>
    /// ��������ύX����
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        GameObject player = null;
        Rigidbody playerRB = null;

        // �Փ˂����I�u�W�F�N�g�̃^�O���v���C���[�Ȃ�I�u�W�F�N�g���擾
        if (other.gameObject.tag == "Player")
        {
            player = other.gameObject;
            playerRB = other.GetComponent<Rigidbody>();
        }

        // �擾�����I�u�W�F�N�g�̈ړ��������擾���A�����̖��O����ύX
        if (player != null)
        {
            if (_isEastWest)
            {
                if (playerRB.velocity.z >= 0) // �k�����ɓ����Ȃ�
                {
                    Debug.Log("playerRB.velocity�F" + playerRB.velocity + " north");
                    _roomManager.SetRoomName(_northEastRoom);
                }
                else    // ������ɓ����Ȃ�
                {
                    Debug.Log("playerRB.velocity�F" + playerRB.velocity + " south");
                    _roomManager.SetRoomName(_southWestRoom);
                }
            }
            else
            {
                if (playerRB.velocity.x >= 0) // �������ɓ����Ȃ�
                {
                    Debug.Log("playerRB.velocity�F" + playerRB.velocity + " east");
                    _roomManager.SetRoomName(_northEastRoom);
                }
                else    // �������ɓ����Ȃ�
                {
                    Debug.Log("playerRB.velocity�F" + playerRB.velocity + " west");
                    _roomManager.SetRoomName(_southWestRoom);
                }
            }
        }
    }
}
