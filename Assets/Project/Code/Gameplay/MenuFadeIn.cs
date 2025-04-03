using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuFadeIn : MonoBehaviour
{
    [Header("Impostazioni Fade In")]
    public Image fadeOverlay;           // UI Image che copre l'intero schermo
    public float fadeInDuration = 1.0f;   // Durata del fade in (da nero a trasparente)

    void Start()
    {
        // Assicurati che l'overlay sia inizialmente nero (opaco)
        Color c = fadeOverlay.color;
        c.a = 1f;
        fadeOverlay.color = c;

        // Avvia la Coroutine per il fade in
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float timer = 0f;
        while (timer < fadeInDuration)
        {
            timer += Time.deltaTime;
            // Interpola l'alpha da 1 (nero) a 0 (trasparente)
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeInDuration);
            Color c = fadeOverlay.color;
            c.a = alpha;
            fadeOverlay.color = c;
            yield return null;
        }
    }
}
