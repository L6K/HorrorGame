using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// このクラスではゾンビに見つかり、ゾンビに殺された時の自分の視点を上向きに変更する
/// </summary>

public class DeadController : MonoBehaviour
{
    Animator _enemyAnime; //ゾンビのアニメーター
    GameObject _me; //カメラの親
    GameObject _meCamera; //カメラ
    Transform _meRotation; //カメラ角度

    // Start is called before the first frame update
    void Start()
    {
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
            }
        }
    }
    //_enemyのアニメーターのboxingアニメーションが起動した瞬間、_meCameraのアニメーションを停止して、カメラのrotationを上げる

    // Update is called once per frame
    void Update()
    {
        if(_enemyAnime.GetCurrentAnimatorStateInfo(0).IsName("boxing")) //boxingステートに遷移した瞬間
        {
            //_meCameraのアニメーションを停止させる
            _meCamera.GetComponent<Animator>().enabled = false;
        }
    }
}
