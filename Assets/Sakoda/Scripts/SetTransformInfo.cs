using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTransformInfo : MonoBehaviour
{
    public GameObject player;
    public GameObject zombie;
    public bool _isMusicClear;

    private void Awake()
    {
        if (_isMusicClear)
        {
            zombie.transform.position = new Vector3(PlayerPrefs.GetFloat("zombiePositionX"), PlayerPrefs.GetFloat("zombiePositionY"), PlayerPrefs.GetFloat("zombiePositionZ"));
            player.transform.position = zombie.transform.position + zombie.transform.forward * 1.5f;
        }
    }
}
