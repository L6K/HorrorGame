using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandle : MonoBehaviour
{
    public GameObject itemManager;

    public void InvestigateItem(RaycastHit hitObject)
    {
        Story whereUse = hitObject.collider.GetComponent<ItemInformation>().whereUse;
        int index = hitObject.collider.GetComponent<ItemInformation>().index;

        itemManager.GetComponent<ItemManager>().ObtainItem(whereUse, index);

        hitObject.collider.GetComponent<GameObject>().SetActive(false);
    }
}
