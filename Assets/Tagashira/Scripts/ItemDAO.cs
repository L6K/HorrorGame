using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDAO : MonoBehaviour
{
    [SerializeField] ItemDataSO[] _itemLists;

    /// <summary>
    /// アイテム情報のインスタンス(ItemData)を取得する
    /// </summary>
    /// <param name="whereUse"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public ItemData GetItemData(Story whereUse, int index)
    {
        // ストーリー情報からデータベースを取得し、データベースからアイテム情報を取得
        ItemDataSO sarchList = _itemLists[(int)whereUse];

        // 取得したデータベースから指定されたインデックスのアイテム情報を取得
        ItemData sarchItem = null;
        if (sarchList != null)
        {
            sarchItem = sarchList.itemDatasList.Find(n => n._index == index);
        }

        return sarchItem;
    }

    /// <summary>
    /// アイテム名(string)を取得する
    /// </summary>
    /// <returns></returns>
    public string GetItemName(Story whereUse, int index)
    {
        ItemData sarchItem = GetItemData(whereUse, index);
        string itemName = sarchItem._itemName;

        return itemName;
    }

    /// <summary>
    /// アイテム画像(Sprite)を取得する
    /// </summary>
    /// <param name="whereUse"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public Sprite GetItemImage(Story whereUse, int index)
    {
        ItemData sarchItem = GetItemData(whereUse, index);
        Sprite itemImage = sarchItem._itemImage;

        return itemImage;
    }
}
