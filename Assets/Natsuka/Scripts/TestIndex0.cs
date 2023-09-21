using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestIndex0 : MonoBehaviour
{
    bool b = true;
    public GameObject x;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(b)
        {
            b = false;
            x.GetComponent<MessageManager>().MessageManage(0);
        }
    }
}
