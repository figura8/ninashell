using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Carica la scena specificata
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Uscita dal gioco (funziona solo in build)
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
