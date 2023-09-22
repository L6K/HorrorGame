using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message5Point : MonoBehaviour
{
    public GameObject _messageManager;
    public GameObject _thirdTrigger;

    public GameObject _messageStartObjectA;
    public GameObject _messageStartObjectB;

    public bool _isStartMessage;

    private void Start()
    {
        
    }

    private void Update()
    {
        _isStartMessage = !_thirdTrigger.GetComponent<ThirdTrigger>()._thirdT;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && _isStartMessage)
        {
            _messageManager.GetComponent<MessageManager>().MessageManage(5);
            _messageStartObjectA.SetActive(false);
            _messageStartObjectB.SetActive(false);
        }
    }
}
