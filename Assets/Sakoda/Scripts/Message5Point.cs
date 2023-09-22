using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message5Point : MonoBehaviour
{
    public GameObject _piano;
    public GameObject _messageManager;
    public GameObject _zombie;
    public bool _isStartMessage;

    private void Start()
    {
        
    }

    private void Update()
    {
        _isStartMessage = _piano.GetComponent<Piano>()._isPianoOpen && _zombie.activeSelf;

        if (_isStartMessage)
        {
            StartCase5Message();
        }
    }

    private void StartCase5Message()
    {
        _messageManager.GetComponent<MessageManager>().MessageManage(5);
        gameObject.SetActive(false);
    }
}
