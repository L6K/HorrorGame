using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// このクラスではゾンビに見つかり、ゾンビに殺された時の自分の視点を上向きに変更する
/// 殺されたら画面が暗転し、タイトルに戻るボタンがあるゲームオーバー画面が表示される
/// </summary>

public class DeadController : MonoBehaviour
{
    Animator _enemyAnime; //ゾンビのアニメーター
    GameObject _me; //カメラの親
    GameObject _meCamera; //カメラ
    int flag = 0;
    public Image _blackOverlay;
    public float _fadeSpeed = 0.5f;
    public TextMeshProUGUI _gameOver;
    public Button _backToTitle;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;

        // マウスカーソルをロック
        Cursor.lockState = CursorLockMode.Locked;

        GameObject _enemy = GameObject.Find("Zombie1"); //ゾンビオブジェクトを取得
        if (_enemy != null)
        {
            Debug.Log("ゾンビ見つけた");
            _enemyAnime = _enemy.GetComponent<Animator>();
        }
        _me = GameObject.Find("FirstPersonController"); //カメラの親オブジェクトを取得
        if (_me != null)
        {
            Debug.Log("カメラの親見つけた");
            Transform _childTransform = _me.transform.Find("Joint"); // 子オブジェクトの名前
            GameObject _tChiledTransform = _childTransform.GameObject();
            Transform childTransform = _tChiledTransform.transform.Find("PlayerCamera");
            if (childTransform != null)
            {
                Debug.Log("カメラ見つけた");
                _meCamera = childTransform.GameObject();
                Animator animator = _meCamera.GetComponent<Animator>();
                animator.SetLayerWeight(1, 1);
                animator.SetLayerWeight(2, 1);
            }
        }
    }
    //_enemyのアニメーターのboxingアニメーションが起動した瞬間、_meCameraのアニメーションを停止して、カメラのrotationを上げる

    // Update is called once per frame
    void Update()
    {
        if(_enemyAnime.GetCurrentAnimatorStateInfo(0).IsName("boxing")) //boxingステートに遷移した瞬間
        {
            Debug.Log("keri");
            flag += 1;
            if(flag==1)
            {
                //_meCameraのアニメーションを停止させる
                StartCoroutine(SwitchCameraAnimation());
            }
            Color overlayColor = _blackOverlay.color;
            overlayColor.a += _fadeSpeed * Time.deltaTime;
            overlayColor.a = Mathf.Clamp01(overlayColor.a);
            _blackOverlay.color = overlayColor;
            if(overlayColor.a >= 1f)
            {
                // マウスカーソルを表示状態にする
                Cursor.visible = true;

                // マウスカーソルのロックを解除する
                Cursor.lockState = CursorLockMode.None;
                _gameOver.gameObject.SetActive(true);
                _backToTitle.gameObject.SetActive(true);
            }


        }
    }
    IEnumerator SwitchCameraAnimation()
    {
        yield return new WaitForSeconds(0.5f);

        Animator animator = _meCamera.GetComponent<Animator>();
        animator.SetLayerWeight(2, 0);
        Debug.Log("今から倒れます");
        animator.SetBool("shake", false);
        animator.SetTrigger("falldown");

        Debug.Log("Layer 0 weight: " + animator.GetLayerWeight(0));
        Debug.Log("Layer 1 weight: " + animator.GetLayerWeight(1));
    }
}
