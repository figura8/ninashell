using DG.Tweening;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    [Header("Pannello Principale")]
    public RectTransform menuPanel;      // Pannello "Menu"
    public CanvasGroup menuCanvasGroup;  // CanvasGroup per il fade del pannello "Menu"

    [Header("Pannelli Associati")]
    public RectTransform aboutPanel;
    public CanvasGroup aboutCanvasGroup;
    public RectTransform settingsPanel;
    public CanvasGroup settingsCanvasGroup;
    public RectTransform chaptersPanel;
    public CanvasGroup chaptersCanvasGroup;

    [Header("Parametri Transizione")]
    public float transitionDuration = 0.5f;
    public float offScreenX = -1920f;     // Posizione a sinistra fuori dallo schermo per il menu
    public float onScreenX = 0f;          // Posizione visibile (centro)
    public float rightOffScreenX = 1920f; // Posizione iniziale a destra per i pannelli associati

    // Mostra il pannello About
    public void ShowAboutPanel()
    {
        TransitionToPanel(aboutPanel, aboutCanvasGroup);
    }

    // Mostra il pannello Settings
    public void ShowSettingsPanel()
    {
        TransitionToPanel(settingsPanel, settingsCanvasGroup);
    }

    // Mostra il pannello Chapters
    public void ShowChaptersPanel()
    {
        TransitionToPanel(chaptersPanel, chaptersCanvasGroup);
    }

    // Metodo generico per la transizione verso un pannello associato
    private void TransitionToPanel(RectTransform associatedPanel, CanvasGroup associatedCanvasGroup)
    {
        // Animazione per il menu principale: fade out e spostamento a sinistra
        menuCanvasGroup.DOFade(0, transitionDuration);
        menuPanel.DOAnchorPosX(offScreenX, transitionDuration);

        // Prepara il pannello associato posizionandolo fuori dallo schermo a destra e rendendolo trasparente
        associatedPanel.anchoredPosition = new Vector2(rightOffScreenX, associatedPanel.anchoredPosition.y);
        associatedCanvasGroup.alpha = 0;

        // Animazione per il pannello associato: spostamento al centro e fade in
        associatedPanel.DOAnchorPosX(onScreenX, transitionDuration);
        associatedCanvasGroup.DOFade(1, transitionDuration);
    }

    // Metodo per tornare al menu principale da un pannello associato
    public void ReturnToMenu(RectTransform currentPanel, CanvasGroup currentCanvasGroup)
    {
        // Animazione per il pannello attuale: fade out e spostamento fuori dallo schermo a destra
        currentCanvasGroup.DOFade(0, transitionDuration);
        currentPanel.DOAnchorPosX(rightOffScreenX, transitionDuration);

        // Animazione per il pannello "Menu": ritorno al centro e fade in
        menuPanel.DOAnchorPosX(onScreenX, transitionDuration);
        menuCanvasGroup.DOFade(1, transitionDuration);
    }
}
