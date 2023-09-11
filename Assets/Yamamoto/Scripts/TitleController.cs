using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleController : MonoBehaviour
{
    public Text synopsisText;
    public Image synpsisImage;
    public Button startButton;
    public Button nextButton;
    // Start is called before the first frame update
    void Start()
    {
        nextButton.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnStartButtonClicked()
    {

        
    }
    void LoadScene()
    {
        SceneManager.LoadScene("Main");
    }
}
