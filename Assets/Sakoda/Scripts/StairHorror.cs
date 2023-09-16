using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairHorror : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = new Vector3(-22, 4, -25);
            other.transform.Rotate(Vector3.up, 180f);
        }
    }
}
