using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string gameScene;
    public string libraryScene;

    public void StartGame() {
        SceneManager.LoadScene(gameScene);
    }

    public void LibraryButton() {
        SceneManager.LoadScene(libraryScene);
    }

    public void SettingsButton() {
        
    }

    public void QuitGame() {
        Application.Quit();
    }
}
