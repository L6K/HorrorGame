using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandle : MonoBehaviour
{
    public GameObject itemManager;
    public bool _isKeyGet;
    public bool _isPaintingGet;
    public GameObject _zombie;
    public GameObject _stair3fObject;
    public GameObject _stair2fObject;
    public GameObject _messageManager;

    /// <summary>
    /// game上でアイテムを取得した際の処理メソッド
    /// </summary>
    /// <param name="hitObject"></param>
    public void InvestigateItem(RaycastHit hitObject)
    {
        Story whereUse = hitObject.collider.GetComponent<ItemInformation>().whereUse;
        int index = hitObject.collider.GetComponent<ItemInformation>().index;
        hitObject.collider.gameObject.SetActive(false);

        itemManager.GetComponent<ItemManager>().ObtainItem(whereUse, index);

        if(hitObject.collider.name == "pianoKey")
        {
            _isKeyGet = true;
            _messageManager.GetComponent<MessageManager>().MessageManage(1);
            _zombie.SetActive(true);
            _zombie.GetComponentInChildren<ChasingPlayer>().enabled = false;
            _zombie.GetComponent<ZombiePatrol>().enabled = false;
        }

        if(hitObject.collider.name == "Painting")
        {
            _isPaintingGet = true;
            _stair3fObject.GetComponent<ChangeT1>().enabled = false;
            _stair2fObject.GetComponent<ChangeT>().enabled = false;
        }
    }
}
