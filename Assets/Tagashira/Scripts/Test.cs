using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        GameObject obj = null;
        string rightRoom = "";
        string leftRoom = "";
        Rigidbody rb = null;
        string roomName = null;

        // タグがプレイヤーなら衝突したオブジェクトを取得
        if (other.gameObject.tag == "Player")
        {
            obj = other.gameObject;
            rb = other.GetComponent<Rigidbody>();
        }

        // 取得したオブジェクトの移動方向を取得し、部屋の名前情報を変更
        if (obj != null)
        {
            if (rb.velocity.x >= 0) // 右方向に動くなら
            {
                roomName = rightRoom;
            }
            else　   // 左方向に動くなら
            {
                roomName = leftRoom;
            }
        }
    }
}
