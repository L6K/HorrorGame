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
        // コンポーネントを取得
        _roomManager = _roomManagerO.GetComponent<RoomManager>();
    }

    /// <summary>
    /// 階数を
    /// </summary>
    /// <param name="other"></param>
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

        // 取得したオブジェクトの移動方向を取得し、階数を変更
        if (player != null)
        {
            if (_isEastWest)
            {
                if (playerRB.velocity.z >= 0) // 北方向に動くなら
                {
                    _roomManager.SetNumOfFloor(_northEastFloor);
                }
                else    // 南方向に動くなら
                {
                    _roomManager.SetNumOfFloor(_southWestFloor);
                }
            }
            else
            {
                if (playerRB.velocity.y >= 0) // 東方向に動くなら
                {
                    _roomManager.SetNumOfFloor(_northEastFloor);
                }
                else    // 西方向に動くなら
                {
                    _roomManager.SetNumOfFloor(_southWestFloor);
                }
            }
        }
    }
}
