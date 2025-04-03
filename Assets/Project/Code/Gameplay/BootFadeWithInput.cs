using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class BootFadeWithInput : MonoBehaviour
{
    [Header("Impostazioni Fade In")]
    public Image fadeOverlay;           // UI Image che copre lo schermo (colore nero)
    public float holdDuration = 0.5f;     // Tempo di attesa prima che inizi il fade in
    public float fadeDuration = 1.0f;     // Durata del fade in (da nero a trasparente)

    [Header("Scena Successiva")]
    public string nextScene = "MainMenu"; // Nome della scena da caricare

    private bool readyForInput = false;   // Indica che il fade è completato e si attende l'input

    void Start()
    {
        // Assicuriamoci che l'overlay parta opaco (nero)
        Color c = fadeOverlay.color;
        c.a = 1f;
        fadeOverlay.color = c;

        // Avvia la Coroutine per il fade in e l'attesa dell'input
        StartCoroutine(FadeInAndWaitForInput());
    }

    IEnumerator FadeInAndWaitForInput()
    {
        // Attendi il tempo di hold prima di iniziare il fade
        yield return new WaitForSeconds(holdDuration);

        // Fade in: dall'opaco (nero) a trasparente (rivelando il logo)
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

        // Assicura che l'overlay sia completamente trasparente
        Color finalColor = fadeOverlay.color;
        finalColor.a = 0f;
        fadeOverlay.color = finalColor;

        // Ora la scena è pronta: attende l'input dell'utente
        readyForInput = true;
        Debug.Log("Fade completato. Premi un tasto o clicca per continuare.");

        // Attendi che l'utente prema un tasto o clicchi
        while (!Input.GetMouseButtonDown(0) && !Input.anyKeyDown)
        {
            yield return null;
        }

        // Una volta ricevuto l'input, carica la scena del menu
        SceneManager.LoadScene(nextScene);
    }
}
