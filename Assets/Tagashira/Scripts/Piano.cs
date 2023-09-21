using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piano : MonoBehaviour, ReceiveItem
{
    ItemData _itemInfo;
    public ItemManager _nowSelectedItem;
    public GameObject _pianoDoor;
    public bool _isPianoOpen;
    public GameObject _messageManager;
    public GameObject _infinityLoop;
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
       if(_itemInfo._whereUse == Story.musicRoom && _itemInfo._index == 0)
        {
            _nowSelectedItem.UseItem();
            _pianoDoor.GetComponent<Animator>().SetTrigger("pianoOpen");
            Debug.Log("Good!");
            _isPianoOpen = true;
            if(_triggerMessage)
            {
                _triggerMessage = false;
                _messageManager.GetComponent<MessageManager>().MessageManage(3);
                _infinityLoop.SetActive(true);
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
