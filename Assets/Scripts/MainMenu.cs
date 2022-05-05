using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string gameScene;

    public void StartGame() {
        SceneManager.LoadScene(gameScene);
    }

    public void SettingsButton() {
        
    }

    public void QuitGame() {
        Application.Quit();
    }
}
