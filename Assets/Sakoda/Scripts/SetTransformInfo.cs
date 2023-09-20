using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTransformInfo : MonoBehaviour
{
    public GameObject player;
    public GameObject zombie;
    public string _isMusicClear;

    private void Awake()
    {
        _isMusicClear = PlayerPrefs.GetString("_isMusicClear");

        if (_isMusicClear.Equals("Clear"))
        {
            zombie.transform.position = new Vector3(PlayerPrefs.GetFloat("zombiePositionX"), PlayerPrefs.GetFloat("zombiePositionY"), PlayerPrefs.GetFloat("zombiePositionZ"));
            player.transform.position = zombie.transform.position + zombie.transform.forward * 1.5f;
        }
    }
}
