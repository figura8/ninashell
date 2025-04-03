using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class BootFadeIn : MonoBehaviour
{
    [Header("Impostazioni Fade In")]
    public Image fadeOverlay;          // UI Image che copre l'intero schermo
    public float holdDuration = 0.5f;    // Tempo di attesa prima del fade (schermo nero)
    public float fadeDuration = 1.0f;    // Durata del fade in (da nero a trasparente)

    [Header("Scena Successiva")]
    public string nextScene = "MainMenu"; // Nome della scena del menu

    void Start()
    {
        // Assicuriamoci che l'overlay parta opaco (nero)
        Color c = fadeOverlay.color;
        c.a = 1f;
        fadeOverlay.color = c;

        // Avvia la Coroutine per il fade in
        StartCoroutine(FadeInAndProceed());
    }

    IEnumerator FadeInAndProceed()
    {
        // Attendi il tempo di hold
        yield return new WaitForSeconds(holdDuration);

        // Fade in: dall'opaco a trasparente
        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            Color c = fadeOverlay.color;
            c.a = alpha;
            fadeOverlay.color = c;
            yield return null;
        }

        // A questo punto il logo è visibile (l'overlay è completamente trasparente)
        // Puoi decidere di attendere qualche secondo in più o passare subito alla scena successiva.
        // Per esempio, attendiamo altri 2 secondi:
        yield return new WaitForSeconds(2.0f);

        // Per passare alla scena del menu, puoi eventualmente iniziare un fade out o caricare direttamente la scena.
        SceneManager.LoadScene(nextScene);
    }
}
