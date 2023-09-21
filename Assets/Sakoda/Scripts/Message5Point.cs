using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message5Point : MonoBehaviour
{
    public GameObject _zombie;
    public GameObject _player;
    public GameObject _piano;
    public GameObject _messageManager;

    private float _distance;
    public bool _isStartDistance;

    private void Update()
    {
        _distance = Vector3.Distance(_zombie.transform.position, _player.transform.position);
        _isStartDistance = _distance <= 10f;

        Debug.Log(_distance);

        if (_isStartDistance && _piano.GetComponent<Piano>()._isPianoOpen)
        {
            Case5MessageStart();
        }
    }

    private void Case5MessageStart()
    {
        _messageManager.GetComponent<MessageManager>().MessageManage(5);
    }
}
