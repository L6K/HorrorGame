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
            Vector3 newPosition = transform.position;  // ���݂̈ʒu���R�s�[
            newPosition.y = 3f;  // y���W���X�V
            transform.position = newPosition;
            GetComponent<Animator>().SetTrigger("col");
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
