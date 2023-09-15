using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastManager
{
    public RaycastHit GetRaycastHitInfo()
    {
        //画面中心からRayを出し衝突判定を行う
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        Debug.DrawLine(ray.origin, ray.origin + ray.direction * 10, Color.red);
        //rayが当たったobjectの情報を格納する
        RaycastHit _hitObject;
        //rayを飛ばす距離
        float _playerVisibility = 3.0f;

        if (Physics.Raycast(ray, out _hitObject, _playerVisibility))
        {
            return _hitObject;
        }
        else
        {
            return new RaycastHit(); // ヒット情報がない場合は空の情報を返す
        }
    }
}
