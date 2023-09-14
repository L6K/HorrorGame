using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ゾンビのcolliderとドアのcolliderが衝突したらゲームオーバーさせる
/// </summary>
public class GameOver : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // ドアとの衝突を判定
        if (other.gameObject.tag == "Door")
        {
            Debug.Log("衝突");
            SceneManager.LoadScene("GameOver");
        }
    }
}
