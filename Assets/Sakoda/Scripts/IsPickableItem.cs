using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsPickableItem : MonoBehaviour
{
    private bool _isRaycastHit = false;

    private void OnTriggerStay(Collider other)
    {

        GetComponent<Outline>().enabled = true;
        _isRaycastHit = true;

    }

    private void OnTriggerExit(Collider other)
    {
        if (_isRaycastHit)
        {
            GetComponent<Outline>().enabled = false;
            _isRaycastHit = false;
        }
    }
}
