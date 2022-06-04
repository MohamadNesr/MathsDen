using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioManager audioManager;
    public string gameScene;
    public GameObject settingsWindow;
    public AudioClip menuClicSound;

    public void StartGame() {
        SceneManager.LoadScene(gameScene);
        AudioManager.instance.PlayClipAt(menuClicSound, transform.position);
        audioManager.audioSource.clip = audioManager.playlist[1];
        audioManager.audioSource.Play();
    }

    public void SettingsButton() {
        AudioManager.instance.PlayClipAt(menuClicSound, transform.position);
        settingsWindow.SetActive(true);
    }

    public void CloseSettingsWindow() {
        AudioManager.instance.PlayClipAt(menuClicSound, transform.position);
        settingsWindow.SetActive(false);
    }

    public void QuitGame() {
        AudioManager.instance.PlayClipAt(menuClicSound, transform.position);
        Application.Quit();
    }
}
