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
        // コンポーネントを取得
        _roomManager = _roomManagerO.GetComponent<RoomManager>();
    }

    /// <summary>
    /// 部屋名を変更する
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
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
            if (_isEastWest)
            {
                if (playerRB.velocity.z >= 0) // 北方向に動くなら
                {
                    Debug.Log("playerRB.velocity：" + playerRB.velocity + " north");
                    _roomManager.SetRoomName(_northEastRoom);
                }
                else    // 南方向に動くなら
                {
                    Debug.Log("playerRB.velocity：" + playerRB.velocity + " south");
                    _roomManager.SetRoomName(_southWestRoom);
                }
            }
            else
            {
                if (playerRB.velocity.x >= 0) // 東方向に動くなら
                {
                    Debug.Log("playerRB.velocity：" + playerRB.velocity + " east");
                    _roomManager.SetRoomName(_northEastRoom);
                }
                else    // 西方向に動くなら
                {
                    Debug.Log("playerRB.velocity：" + playerRB.velocity + " west");
                    _roomManager.SetRoomName(_southWestRoom);
                }
            }
        }
    }
}
