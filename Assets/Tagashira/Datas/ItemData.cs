using UnityEngine;

[System.Serializable]
public class ItemData
{
    public string _itemName;
    public int _index;
    public Story _whereUse;     // 今のところMusicRoom, Anotherの2つある
    public bool _isUsed;

    public Sprite _itemImage;
}
