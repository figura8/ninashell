using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelManager : MonoBehaviour
{
    [Header("Transizioni UI - Pannello Principale (Menu)")]
    public RectTransform menuPanel;
    public CanvasGroup menuCanvasGroup;

    [Header("Transizioni UI - Pannelli Associati")]
    public RectTransform aboutPanel;
    public CanvasGroup aboutCanvasGroup;
    public RectTransform settingsPanel;
    public CanvasGroup settingsCanvasGroup;
    public RectTransform chaptersPanel;
    public CanvasGroup chaptersCanvasGroup;

    [Header("Parametri Transizione")]
    public float transitionDuration = 0.5f;
    public float offScreenX = -1920f;     // Posizione a sinistra fuori dallo schermo per il Menu
    public float onScreenX = 0f;          // Posizione visibile (centro)
    public float rightOffScreenX = 1920f; // Posizione iniziale a destra per i pannelli associati

    // -------------------------
    // Transizioni dei Pannelli
    // -------------------------

    // Mostra il pannello "About"
    public void ShowAboutPanel()
    {
        TransitionToPanel(aboutPanel, aboutCanvasGroup);
    }

    // Mostra il pannello "Settings"
    public void ShowSettingsPanel()
    {
        TransitionToPanel(settingsPanel, settingsCanvasGroup);
    }

    // Mostra il pannello "Chapters"
    public void ShowChaptersPanel()
    {
        TransitionToPanel(chaptersPanel, chaptersCanvasGroup);
    }

    // Metodo generico per la transizione verso un pannello associato
    private void TransitionToPanel(RectTransform panel, CanvasGroup canvasGroup)
    {
        // Anima il pannello "Menu": fade out e spostamento a sinistra
        menuCanvasGroup.DOFade(0, transitionDuration);
        menuPanel.DOAnchorPosX(offScreenX, transitionDuration);

        // Prepara il pannello associato: posizionalo fuori a destra e rendilo trasparente
        panel.anchoredPosition = new Vector2(rightOffScreenX, panel.anchoredPosition.y);
        canvasGroup.alpha = 0;

        // Anima il pannello associato: spostamento al centro e fade in
        panel.DOAnchorPosX(onScreenX, transitionDuration);
        canvasGroup.DOFade(1, transitionDuration);
    }

    // Metodo per tornare al pannello "Menu" da un pannello associato
    public void ReturnToMenu(RectTransform currentPanel, CanvasGroup currentCanvasGroup)
    {
        // Animazione per il pannello attuale: fade out e spostamento fuori a destra
        currentCanvasGroup.DOFade(0, transitionDuration);
        currentPanel.DOAnchorPosX(rightOffScreenX, transitionDuration);

        // Animazione per il pannello "Menu": ritorno al centro e fade in
        menuPanel.DOAnchorPosX(onScreenX, transitionDuration);
        menuCanvasGroup.DOFade(1, transitionDuration);
    }

    public void ReturnToMenuFromAbout()
    {
        ReturnToMenu(aboutPanel, aboutCanvasGroup);
    }

    public void ReturnToMenuFromSettings()
    {
        ReturnToMenu(settingsPanel, settingsCanvasGroup);
    }

    // Metodo per tornare al Menu dal pannello Chapters
    public void ReturnToMenuFromChapters()
    {
        ReturnToMenu(chaptersPanel, chaptersCanvasGroup);
    }


    // -------------------------
    // Gestione delle Scene
    // -------------------------

    // Carica la scena specificata
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Esce dal gioco (funziona solo in build)
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
