using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioManager audioManager;
    public string gameScene;

    public void StartGame() {
        SceneManager.LoadScene(gameScene);
        audioManager.audioSource.clip = audioManager.playlist[1];
        audioManager.audioSource.Play();
    }

    public void SettingsButton() {
        
    }

    public void QuitGame() {
        Application.Quit();
    }
}
