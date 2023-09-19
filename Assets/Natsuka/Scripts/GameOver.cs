using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ゾンビのcolliderとドアのcolliderが衝突したらゲームオーバーさせる
/// </summary>
public class GameOver : MonoBehaviour
{
    public bool _clear = false;
    public GameObject _player;

    private void OnTriggerEnter(Collider other)
    { 
        // ドアとの衝突を判定
        if (other.gameObject.tag == "Door")
        {
            if (_player.GetComponent<HighlightController>()._isHiding) //ロッカーに隠れているとき
            {
                Debug.Log("good!");
                gameObject.SetActive(false);
                _clear = true;
            }
            else //ゲームオーバー時
            {
                Debug.Log("衝突");
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}
