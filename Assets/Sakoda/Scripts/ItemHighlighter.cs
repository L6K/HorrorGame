using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHighlighter : MonoBehaviour
{
    private Ray _ray;

    // Update is called once per frame
    void Update()
    {
        //画面中心から常にRayを出し続ける
        _ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        Debug.DrawLine(_ray.origin, _ray.origin + _ray.direction * 10, Color.red);
    }

    /*
     * <summary>
     * 各オブジェクトが持つコライダーにplayerが入ったら、処理を行う
     * </summary>
     */
    private void OnTriggerStay(Collider other)
    {
        //rayが当たったobjectの情報を格納する
        RaycastHit _hitObject;
        //playerの視界の長さ
        float _playerVisibility = 10.0f;
 
        if (other.CompareTag("ItemCollider"))
        {
            Outline outline = other.GetComponentInChildren<Outline>();
            Debug.Log(outline);
            if (Physics.Raycast(_ray, out _hitObject, _playerVisibility))
            {
                if (_hitObject.collider.CompareTag("Item"))
                {
                    Debug.Log(_hitObject.collider.gameObject);
                    outline.enabled = true;
                }
                else
                {
                    outline.enabled = false;
                }
            }
        }
    }

    /*
     * <summary>
     * playerが対象のobjectから離れたときに処理を行う
     * </summary>
     */
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ItemCollider"))
        {
            other.GetComponentInChildren<Outline>().enabled = false;
        }
    }
}
