using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplayer : MonoBehaviour
{
    private ItemData _displayItem;
    private Image _itemImage;

    [SerializeField] private Image _background;
    [SerializeField] private Color _default;
    [SerializeField] private Color _highLight;
    [SerializeField] private GameObject _itemImageDisplayer;

    public bool _isSelected;

    void Start()
    {
        _background.color = _default;
        _isSelected = false;
    }

    public void ItemDisplay(ItemData displayItem, bool isSelected)
    {
        _displayItem = displayItem;
        _isSelected = isSelected;

        // 子オブジェクトのImageコンポーネントを取得
        _itemImage = _itemImageDisplayer.GetComponent<Image>();

        // アイテムを選択されているならパネルの色を変更
        if (isSelected)
        {
            _background.color = _highLight;
        }
        else
        {
            _background.color = _default;
        }

        Debug.Log(_itemImage);

        // スプライトを表示
        _itemImage.sprite = _displayItem._itemImage;
    }
}
