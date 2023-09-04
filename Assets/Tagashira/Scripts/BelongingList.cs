using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BelongingList : MonoBehaviour
{
    private ItemDAO _itemDAO;

    [SerializeField] private GameObject _itemDatabase;
    [SerializeField] private Story[] _whereUse;
    [SerializeField] private int[] _index;

    public List<ItemData> _belongings;

    // Start is called before the first frame update
    void Start()
    {
        // コンポーネントを取得
        _itemDAO = _itemDatabase.GetComponent<ItemDAO>();

        _belongings = new List<ItemData>();

        // 初期アイテムをリストに格納
        for (int i = 0; i < _whereUse.Length; i++)
        {
            _belongings.Add(_itemDAO.GetItemData(_whereUse[i], _index[i]));
        }
    }
}
