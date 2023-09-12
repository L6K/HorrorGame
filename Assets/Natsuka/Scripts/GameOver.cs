using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    //ゾンビのcolliderとドアのcolliderが衝突したらゲームオーバー
    //ゲームオーバーしたら時間を止める
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // ドアとの衝突を判定
        if (other.gameObject.tag == "Door")
        {
            
            SceneManager.LoadScene("GameOver");
            // ここで何かの処理を行う（ドアを開ける、ゾンビを止める等）
        }
    }
}
