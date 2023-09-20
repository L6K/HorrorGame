using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeT : MonoBehaviour
{

    public GameObject fpc;
    private int _flag = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        Vector3 newPosition = fpc.transform.position;  // 現在の位置をコピー
        newPosition.y += 3f;  // y座標を更新
        fpc.transform.position = newPosition;  // 新しい位置を設定
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _flag += 1;
            Debug.Log(_flag);
        }
        if (_flag == 3)
        {
            //無限ループ三回目以降の処理
            Debug.Log("third loop");
        }
    }
}
