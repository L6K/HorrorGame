using UnityEngine;

[System.Serializable]
public class ItemData
{
    public string _itemName;
    public int _index;
    public Story _whereUse;     // ¡‚Ì‚Æ‚±‚ëMusicRoom, Else‚Ì2‚Â‚ ‚é
    public bool _isUsed;

    public Sprite _itemImage;
}
