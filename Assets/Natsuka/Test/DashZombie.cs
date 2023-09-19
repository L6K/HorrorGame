using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashZombie : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Floor"))
        {
            transform.Rotate(0f, 90f, 0f);
            Vector3 newPosition = transform.position;  // 現在の位置をコピー
            newPosition.y = 3f;  // y座標を更新
            transform.position = newPosition;
            GetComponent<Animator>().SetTrigger("col");
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
