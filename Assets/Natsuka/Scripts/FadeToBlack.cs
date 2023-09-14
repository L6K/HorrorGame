using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ƒvƒŒƒCƒ„[‚ªƒ]ƒ“ƒr‚ÉE‚³‚ê‚éÛ‚É‰æ–Ê‚ªˆÃ“]‚·‚éˆ—
/// </summary>
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