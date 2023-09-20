using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ゾンビのcolliderとドアのcolliderが衝突したらゲームオーバーさせる
/// </summary>
public class GameOver : MonoBehaviour
{
    public GameObject _player;

    private void OnTriggerEnter(Collider other)
    { 
        // ドアとの衝突を判定
        if (other.gameObject.tag == "Door")
        {
            if (_player.GetComponent<HighlightController>()._isHiding)
            {
                
                gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("衝突");
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}
