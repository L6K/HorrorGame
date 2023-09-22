using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Easel : MonoBehaviour, ReceiveItem
{
    ItemData _itemInfo;
    public ItemManager _nowSelectedItem;
    public bool _isPaintingInstallation;
    public GameObject _messageManager;
    public GameObject _installingPainting;
    private bool _triggerMessage = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _itemInfo = _nowSelectedItem.GetSelectedItem();
    }

    public void ReceiveAciton()
    {
       if(_itemInfo._whereUse == Story.artRoom && _itemInfo._index == 0)
        {
            _nowSelectedItem.UseItem();
            _installingPainting.SetActive(true);
            Debug.Log("Good!");
            _isPaintingInstallation = true;

            if(_triggerMessage)
            {
                _triggerMessage = false;
                _messageManager.GetComponent<MessageManager>().MessageManage(5);
            }
            

        }
    }

    public void GetStory()
    {

    }

    public void GetIndex()
    {

    }
}
