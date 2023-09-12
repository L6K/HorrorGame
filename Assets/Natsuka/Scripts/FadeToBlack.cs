using UnityEngine;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour
{
    public Image blackOverlay;
    public float fadeSpeed = 0.5f;

    private void Update()
    {
        
        Color overlayColor = blackOverlay.color;
        overlayColor.a += fadeSpeed * Time.deltaTime;
        overlayColor.a = Mathf.Clamp01(overlayColor.a);
        blackOverlay.color = overlayColor;
    }
}