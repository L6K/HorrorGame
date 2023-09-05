using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.UI;

public class ItemUIManager : MonoBehaviour
{
    private const int NUMBER_OF_ITEM_DISPLAY = 7;
    private const int UNSELECTED_ITEM = -1;

    private ItemDAO _itemDAO;
    private List<ItemData> _itemList;
    private List<ItemData> _displayItemList;
    private int _nowDisplayPage;
    private int _maxDisplayPage;
    private bool _isCanPrevPage;
    private bool _isCanNextPage;
    private ItemData _nothing;
    private Text _displayItemName;
    private bool _isFadeout;

    [SerializeField] private Story _storyOfNothing;
    [SerializeField] private int _indexOfNothing;
    
    [SerializeField] private GameObject _itemDatabase;
    [SerializeField] private GameObject _belongings;

    [SerializeField] private GameObject _prevItemBotton;
    [SerializeField] private GameObject _nextItemBotton;
    [SerializeField] private GameObject[] _itemDisplayers;
    [SerializeField] private GameObject _itemNameText;
    [SerializeField] private float _timeOfDisplayItemName;
    [SerializeField] private float _fadeoutSpeed;

    public int _selectItemPanel;

    void Start()
    {
        // コンポーネントを取得
        _itemDAO = _itemDatabase.GetComponent<ItemDAO>();
        _displayItemName = _itemNameText.GetComponent<Text>();

        // アイテム名は必要な時だけ表示するので非表示にする
        _itemNameText.SetActive(false);

        // 所持アイテムのリストを取得
        _itemList = _belongings.GetComponent<BelongingList>()._belongings;

        // 表示するアイテムのリストを作成
        _displayItemList = new List<ItemData>();

        _nowDisplayPage = 1;

        // どのアイテムが選択されているか
        _selectItemPanel = UNSELECTED_ITEM;

        // 最大ページ数を計算(所持アイテム数により変動)
        _maxDisplayPage = _itemList.Count / NUMBER_OF_ITEM_DISPLAY;
        bool isDivisible = _itemList.Count % NUMBER_OF_ITEM_DISPLAY == 0;
        bool isNoItem = _itemList.Count == 0;

        if (!isDivisible || isNoItem)
        {
            _maxDisplayPage++;
        }

        // アイテムを持っていないマス用のアイテム(nothing)のインスタンスを取得
        _nothing = _itemDAO.GetItemData(_storyOfNothing, _indexOfNothing);

        // UIにアイテムを表示
        UpdateDisplayItemList();

        LoadItemPanel();
    }

    // Update is called once per frame
    void Update()
    {
        // ページ切り替えボタンの表示非表示切り替え
        // 前のページがあるか判定
        if (_nowDisplayPage > 1)
        {
            _isCanPrevPage = true;
        }
        else
        {
            _isCanPrevPage = false;
        }
        // 次のページがあるか判定
        if (_nowDisplayPage < _maxDisplayPage)
        {
            _isCanNextPage = true;
        }
        else
        {
            _isCanNextPage = false;
        }

        // 前のページ(←)
        if (_isCanPrevPage)
        {
            _prevItemBotton.SetActive(true);
        }
        else
        {
            _prevItemBotton.SetActive(false);
        }

        // 次のページ(→)
        if (_isCanNextPage)
        {
            _nextItemBotton.SetActive(true);
        }
        else
        {
            _nextItemBotton.SetActive(false);
        }

        Color textColor = _displayItemName.color;

        // アイテム名の表示テキストをフェードアウトさせる
        if (_isFadeout)
        {
            if (_displayItemName.color.a - _fadeoutSpeed <= 0)
            {
                textColor.a = 0;
                _displayItemName.color = textColor;

                _itemNameText.SetActive(false);
                textColor.a = 255;
                _displayItemName.color = textColor;

                _isFadeout = false;
            }
            else
            {
                textColor.a -= _fadeoutSpeed;
                _displayItemName.color = textColor;
            }
        }
    }

    /// <summary>
    /// _displayItemListを更新するメソッド
    /// </summary>
    public void UpdateDisplayItemList()
    {
        // _displayItemListをクリア
        _displayItemList.Clear();

        // _itemListの何番目から何番目までのアイテムを表示するか計算
        int firstItem = (_nowDisplayPage - 1) * NUMBER_OF_ITEM_DISPLAY;
        int lastItem = firstItem + NUMBER_OF_ITEM_DISPLAY;

        // アイテムが無いマスの数を計算(nothingが入る)
        int numberOfBrank = 0;

        if (lastItem > _itemList.Count)
        {
            numberOfBrank = lastItem - _itemList.Count;
        }

        // _displayItemLIstに表示するアイテムを格納
        for (int i = firstItem; i < lastItem; i++)
        {
            if (i < _itemList.Count)
            {
                _displayItemList.Add(_itemList[i]);
            }
            else
            {
                // 空欄はnothingを格納
                _displayItemList.Add(_nothing);
            }
        }
    }

    /// <summary>
    /// アイテムのUIを読み込むメソッド(更新にも使う)
    /// </summary>
    public void LoadItemPanel()
    {
        for (int i = 0; i < NUMBER_OF_ITEM_DISPLAY; i++)
        {
            // ItemDisplayerを取得しアイテムパネルの情報を反映させる
            ItemDisplayer displayer = _itemDisplayers[i].GetComponent<ItemDisplayer>();

            bool isSelected = _selectItemPanel == i;
            displayer.ItemDisplay(_displayItemList[i], isSelected);
        }
    }

    /// <summary>
    /// アイテムの前のページを表示するメソッド
    /// </summary>
    public void PrevItemPage()
    {
        // 表示ページを1つ前に戻る
        _nowDisplayPage--;

        // 選択アイテムをリセット
        _selectItemPanel = UNSELECTED_ITEM;

        // UIに反映
        UpdateDisplayItemList();
        LoadItemPanel();
    }

    /// <summary>
    /// アイテムの次のページを表示するメソッド
    /// </summary>
    public void NextItemPage()
    {
        // 表示ページを次に進める
        _nowDisplayPage++;

        // 選択アイテムをリセット
        _selectItemPanel = UNSELECTED_ITEM;

        // UIに反映
        UpdateDisplayItemList();
        LoadItemPanel();
    }

    /// <summary>
    /// UIからアイテムを選択された時の処理を行うメソッド
    /// </summary>
    /// <param name="numberOfPanel"></param>
    public void SelectItem(int numberOfPanel)
    {
        // 選択されたのがnothingなら処理しない
        bool isNothing = _displayItemList[numberOfPanel]._itemName == _nothing._itemName;

        if (isNothing)
        {
            return;
        }

        // 現在選択されているアイテムが再び選択されたら何も選択していない状態に戻す
        // 別のアイテムが選択された場合は現在選択されているアイテムを変更
        if (_selectItemPanel == numberOfPanel)
        {
            _selectItemPanel = UNSELECTED_ITEM;
        }
        else
        {
            _selectItemPanel = numberOfPanel;

            // アイテム名表示のテキストを選択されたアイテムに変更
            _displayItemName.text = _displayItemList[numberOfPanel]._itemName;
            _itemNameText.SetActive(true);

            // インスペクターで指定された秒数表示し、経過したら非活性に戻す
            Invoke("FadeoutText", _timeOfDisplayItemName);
        }

        // UIに反映
        UpdateDisplayItemList();
        LoadItemPanel();
    }

    void FadeoutText()
    {
        _isFadeout = true;
    }

    // 覚書：アイテム選択情報をどこかに渡すメソッドは別で作ってメソッド呼び出しで処理する
}
