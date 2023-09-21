using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdTrigger : MonoBehaviour
{
    public bool _thirdT = true;
    GameObject _messageManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(_thirdT)
            {
                _thirdT = false;
                _messageManager.GetComponent<MessageManager>().MessageManage(4);
            }
        }
    }
}
