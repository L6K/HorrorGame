using UnityEngine;

[System.Serializable]
public class ItemData
{
    public string _itemName;
    public int _index;
    public Story _whereUse;     // ���̂Ƃ���MusicRoom, Else��2����
    public bool _isUsed;

    public Sprite _itemImage;
}
