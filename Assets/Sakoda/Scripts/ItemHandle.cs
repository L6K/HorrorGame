using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandle : MonoBehaviour
{
    public GameObject itemManager;
    public bool _isTalking;

    public void InvestigateItem(RaycastHit hitObject)
    {
        Story whereUse = hitObject.collider.GetComponent<ItemInformation>().whereUse;
        int index = hitObject.collider.GetComponent<ItemInformation>().index;
        hitObject.collider.gameObject.SetActive(false);

        itemManager.GetComponent<ItemManager>().ObtainItem(whereUse, index);

        _isTalking = true;
    }
}
