using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

/// <summary>
/// テーブルの管理クラス
/// </summary>
[System.Serializable]
public class TableBase<TKey, TValue, Type> where Type : KeyAndValue<TKey, TValue>
{
    [SerializeField]
    public List<Type> _list;
    public OrderedDictionary _table;

    public OrderedDictionary GetTable()
    {
        if (_table == null)
        {
            _table = ConvertListToDictionary(_list);
        }
        return _table;
    }

    /// <summary>
    /// Editor Only
    /// </summary>
    public List<Type> GetList()
    {
        return _list;
    }

    static OrderedDictionary ConvertListToDictionary(List<Type> list)
    {
        //Dictionary<TKey, TValue> dic = new Dictionary<TKey, TValue>();
        OrderedDictionary dic = new OrderedDictionary();
        foreach (KeyAndValue<TKey, TValue> pair in list)
        {
            dic.Add(pair.story, pair.index);
        }
        return dic;
    }
}

/// <summary>
/// シリアル化できる、KeyValuePair
/// </summary>
[System.Serializable]
public class KeyAndValue<TKey, TValue>
{
    public TKey story;
    public TValue index;

    public KeyAndValue(TKey key, TValue value)
    {
        story = key;
        index = value;
    }
    public KeyAndValue(KeyValuePair<TKey, TValue> pair)
    {
        story = pair.Key;
        index = pair.Value;
    }
}

