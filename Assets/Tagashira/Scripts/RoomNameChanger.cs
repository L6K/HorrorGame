using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNameChanger : MonoBehaviour
{
    private RoomManager _roomManager;

    [SerializeField] private string _northEastRoom;
    [SerializeField] private string _southWestRoom;
    [SerializeField] private GameObject _roomManagerO;
    [SerializeField] private bool _isZ;

    // Start is called before the first frame update
    void Start()
    {
        // コンポーネントを取得
        _roomManager = _roomManager.GetComponent<RoomManager>();
    }

    private void OnTriggerStay(Collider other)
    {
        GameObject player = null;
        Rigidbody playerRB = null;

        // 衝突したオブジェクトのタグがプレイヤーならオブジェクトを取得
        if (other.gameObject.tag == "Player")
        {
            player = other.gameObject;
            playerRB = other.GetComponent<Rigidbody>();
        }

        // 取得したオブジェクトの移動方向を取得し、部屋の名前情報を変更
        if (player != null)
        {
            if (_isZ)
            {
                if (playerRB.velocity.z >= 0) // 北方向に動くなら
                {
                    _roomManager.SetRoomName(_northEastRoom);
                }
                else    // 南方向に動くなら
                {
                    _roomManager.SetRoomName(_southWestRoom);
                }
            }
            else
            {
                if (playerRB.velocity.y >= 0) // 東方向に動くなら
                {
                    _roomManager.SetRoomName(_northEastRoom);
                }
                else    // 西方向に動くなら
                {
                    _roomManager.SetRoomName(_southWestRoom);
                }
            }
        }
    }
}
