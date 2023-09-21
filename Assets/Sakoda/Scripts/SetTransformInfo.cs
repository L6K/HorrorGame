using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTransformInfo : MonoBehaviour
{
    public GameObject _player;
    public GameObject _zombie;
    public GameObject _storyDitecter;

    private void Awake()
    {
        if (_storyDitecter.GetComponent<MusicRoomClearDitecter>()._isMusicRoomCleared)
        {
            _zombie.transform.position = new Vector3(PlayerPrefs.GetFloat("zombiePositionX"), PlayerPrefs.GetFloat("zombiePositionY"), PlayerPrefs.GetFloat("zombiePositionZ"));
            _zombie.transform.rotation = Quaternion.Euler(0, -90, 0);
            _player.transform.position = _zombie.transform.position + _zombie.transform.forward * 1f;
            _player.transform.rotation = Quaternion.LookRotation(-_zombie.transform.forward, _player.transform.up);
        }
    }
}
