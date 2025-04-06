using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScaleOnClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Fattore di scala da applicare quando si preme l'immagine
    public float scaleMultiplier = 1.2f;
    // Durata dell'animazione per ingrandire e ridurre l'immagine
    public float animationDuration = 0.2f;

    private Vector3 originalScale;

    private void Awake()
    {
        // Salva la scala originale dell'oggetto
        originalScale = transform.localScale;
    }

    // Quando l'utente preme sull'immagine
    public void OnPointerDown(PointerEventData eventData)
    {
        // Anima l'immagine fino a scaleMultiplier, utilizzando il pivot impostato
        transform.DOScale(originalScale * scaleMultiplier, animationDuration).SetEase(Ease.OutQuad);
    }

    // Quando l'utente rilascia l'immagine
    public void OnPointerUp(PointerEventData eventData)
    {
        // Riporta l'immagine alla scala originale
        transform.DOScale(originalScale, animationDuration).SetEase(Ease.InQuad);
    }
}
