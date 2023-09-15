using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepNumChanger : MonoBehaviour
{
    private RoomManager _roomManager;

    [SerializeField] private GameObject _roomManagerO;
    [SerializeField] private string _northEastFloor;
    [SerializeField] private string _southWestFloor;
    [SerializeField] private bool _isEastWest;

    // Start is called before the first frame update
    void Start()
    {
        // �R���|�[�l���g���擾
        _roomManager = _roomManagerO.GetComponent<RoomManager>();
    }

    /// <summary>
    /// �K����
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        GameObject player = null;
        Rigidbody playerRB = null;

        // �Փ˂����I�u�W�F�N�g�̃^�O���v���C���[�Ȃ�I�u�W�F�N�g���擾
        if (other.gameObject.tag == "Player")
        {
            player = other.gameObject;
            playerRB = other.GetComponent<Rigidbody>();
        }

        // �擾�����I�u�W�F�N�g�̈ړ��������擾���A�K����ύX
        if (player != null)
        {
            if (_isEastWest)
            {
                if (playerRB.velocity.z >= 0) // �k�����ɓ����Ȃ�
                {
                    _roomManager.SetNumOfFloor(_northEastFloor);
                }
                else    // ������ɓ����Ȃ�
                {
                    _roomManager.SetNumOfFloor(_southWestFloor);
                }
            }
            else
            {
                if (playerRB.velocity.y >= 0) // �������ɓ����Ȃ�
                {
                    _roomManager.SetNumOfFloor(_northEastFloor);
                }
                else    // �������ɓ����Ȃ�
                {
                    _roomManager.SetNumOfFloor(_southWestFloor);
                }
            }
        }
    }
}
