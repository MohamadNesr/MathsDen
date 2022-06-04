using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioManager audioManager;
    public string gameScene;
    public GameObject settingsWindow;

    public void StartGame() {
        SceneManager.LoadScene(gameScene);
        audioManager.audioSource.clip = audioManager.playlist[1];
        audioManager.audioSource.Play();
    }

    public void SettingsButton() {
        settingsWindow.SetActive(true);
    }

    public void CloseSettingsWindow() {
        settingsWindow.SetActive(false);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
