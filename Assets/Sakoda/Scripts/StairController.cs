using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FirstPersonController firstPerson = other.GetComponent<FirstPersonController>();
            firstPerson.walkSpeed = 3.0f;
            firstPerson.bobAmount = new Vector3(.0f, .125f, 0f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FirstPersonController firstPerson = other.GetComponent<FirstPersonController>();
            firstPerson.walkSpeed = 5.0f;
            firstPerson.bobAmount = new Vector3(.0f, .1f, 0f);
        }
    }
}
