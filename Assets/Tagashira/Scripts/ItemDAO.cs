using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDAO : MonoBehaviour
{
    [SerializeField] ItemDataSO[] _itemLists;

    /// <summary>
    /// �A�C�e�����̃C���X�^���X(ItemData)���擾����
    /// </summary>
    /// <param name="whereUse"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public ItemData GetItemData(Story whereUse, int index)
    {
        // �X�g�[���[��񂩂�f�[�^�x�[�X���擾���A�f�[�^�x�[�X����A�C�e�������擾
        ItemDataSO sarchList = _itemLists[(int)whereUse];

        // �擾�����f�[�^�x�[�X����w�肳�ꂽ�C���f�b�N�X�̃A�C�e�������擾
        ItemData sarchItem = null;
        if (sarchList != null)
        {
            sarchItem = sarchList.itemDatasList.Find(n => n._index == index);
        }

        return sarchItem;
    }

    /// <summary>
    /// �A�C�e����(string)���擾����
    /// </summary>
    /// <returns></returns>
    public string GetItemName(Story whereUse, int index)
    {
        ItemData sarchItem = GetItemData(whereUse, index);
        string itemName = sarchItem._itemName;

        return itemName;
    }

    /// <summary>
    /// �A�C�e���摜(Sprite)���擾����
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
