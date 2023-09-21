using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ゾンビのcolliderとドアのcolliderが衝突したらゲームオーバーさせる
/// </summary>
public class GameOver : MonoBehaviour
{
    public int _clear = 0;
    public GameObject _player;
    public GameObject _mm;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        // ドアとの衝突を判定
        if (other.gameObject.tag == "Door")
        {
            if (_player.GetComponent<HighlightController>()._isHiding) //ロッカーに隠れているとき
            {
                
                gameObject.SetActive(false);
                _mm.GetComponent<MessageManager>().MessageManage(2);
            }
            else //ゲームオーバー時
            {
                Debug.Log("衝突");
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}