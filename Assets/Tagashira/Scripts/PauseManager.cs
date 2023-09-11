using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool _isPause;

    [SerializeField] private GameObject _pauseCanvas;

    private void Start()
    {
        _pauseCanvas.SetActive(false);
    }

    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!_isPause)
            {
                Time.timeScale = 0;
                _pauseCanvas.SetActive(true);
                _isPause = true;
            }
            else
            {
                Time.timeScale = 1;
                _pauseCanvas.SetActive(false);
                _isPause = false;
            }
        }
        */

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 0;
            _pauseCanvas.SetActive(true);
            _isPause = true;
        }
    }
}
