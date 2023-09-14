using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private ItemDAO _itemDAO;
    private List<ItemData> _belongingList;
    private ItemUIManager _itemUIManager;

    [SerializeField] private GameObject _itemDatabase;
    [SerializeField] private GameObject _belongings;
    [SerializeField] private GameObject _itemPanel;

    [SerializeField] private ItemData _nowSelectedItem;

    void Start()
    {
        // コンポーネントを取得
        _itemDAO = _itemDatabase.GetComponent<ItemDAO>();
        _belongingList = _belongings.GetComponent<BelongingList>()._belongings;
        _itemUIManager = _itemPanel.GetComponent<ItemUIManager>();
    }

    /// <summary>
    /// アイテムを入手の処理を行うメソッド。情報を受け取って所持品リストに追加、UIに反映する。
    /// </summary>
    /// <param name="whereUse"></param>
    /// <param name="Index"></param>
    public void ObtainItem(Story whereUse, int index)
    {
        // 入手したアイテムの情報を取得
        ItemData obtainItem = _itemDAO.GetItemData(whereUse, index);

        // 所持品リストに追加
        _belongingList.Add(obtainItem);

        // UIに反映
        _itemUIManager.CulcDisplayPage();
        _itemUIManager.UpdateDisplayItemList();
        _itemUIManager.LoadItemPanel();
    }

    /// <summary>
    /// 選択されたアイテムの情報を受け取りフィールドに保持するメソッド
    /// </summary>
    /// <param name="selectedItem"></param>
    public void SetSelectedItem(ItemData selectedItem)
    {
        _nowSelectedItem = selectedItem;
    }

    /// <summary>
    /// 選択されたアイテムの情報を返すメソッド
    /// </summary>
    /// <returns></returns>
    public ItemData GetSelectedItem()
    {
        return _nowSelectedItem;
    }

    /// <summary>
    /// アイテム使用の際のデータ的な処理(所持品リスト、UIの更新)
    /// </summary>
    public void UseItem()
    {
        // 所持品リストからアイテムを削除
        _belongingList.Remove(_nowSelectedItem);

        // UIに反映
        _itemUIManager.CulcDisplayPage();
        _itemUIManager.UpdateDisplayItemList();
        _itemUIManager.LoadItemPanel();
    }
}
