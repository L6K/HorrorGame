using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPicker : MonoBehaviour
{
    private bool _isRaycastHit;

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay
            (new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        Physics.Raycast(ray, out hit, 10.0f);
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            other.GetComponent<Outline>().enabled = true;
        }
    }
}
