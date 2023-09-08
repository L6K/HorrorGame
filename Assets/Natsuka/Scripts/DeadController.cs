using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// このクラスではゾンビに見つかり、ゾンビに殺された時の自分の視点を上向きに変更する
/// </summary>

public class DeadController : MonoBehaviour
{
    GameObject _enemy; //ゾンビ
    GameObject _me; //カメラの親
    GameObject _meCamera; //カメラ
    Transform _meRotation; //カメラ角度

    // Start is called before the first frame update
    void Start()
    {
        _enemy = GameObject.Find("Zombie1"); //ゾンビオブジェクトを取得
        _me = GameObject.Find("FirstPersonController"); //カメラの親オブジェクトを取得
        GameObject parentObject = GameObject.Find("ParentObjectName"); // 親オブジェクトの名前
        if (parentObject != null)
        {
            Transform childTransform = parentObject.transform.Find("PlayerCamera"); // 子オブジェクトの名前
            if (childTransform != null)
            {
                _meCamera = childTransform.GameObject();
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
