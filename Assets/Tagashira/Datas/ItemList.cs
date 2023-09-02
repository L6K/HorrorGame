using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// ジェネリックを隠すために継承してしまう
/// [System.Serializable]を書くのを忘れない
/// </summary>
[System.Serializable]
public class SampleTable : TableBase<Story, int, SamplePair>
{


}

/// <summary>
/// ジェネリックを隠すために継承してしまう
/// [System.Serializable]を書くのを忘れない
/// </summary>
[System.Serializable]
public class SamplePair : KeyAndValue<Story, int>
{

    public SamplePair(Story key, int value) : base(key, value)
    {

    }
}

public class ItemList : MonoBehaviour
{

    //Inspectorに表示できるデータテーブル
    public SampleTable _item;

    void Awake()
    {
        //内容を列挙
        foreach (KeyValuePair<Story, int> pair in _item.GetTable())
        {
            Debug.Log("Key : " + pair.Key + "  Value : " + pair.Value);
        }
    }

}