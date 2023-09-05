using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastManager
{
    public RaycastHit GetRaycastHitInfo()
    {
        //画面中心からRayを出し衝突判定を行う
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        //rayが当たったobjectの情報を格納する
        RaycastHit _hitObject;

        if (Physics.Raycast(ray, out _hitObject))
        {
            return _hitObject;
        }
        else
        {
            return new RaycastHit(); // ヒット情報がない場合は空の情報を返す
        }
    }
}
