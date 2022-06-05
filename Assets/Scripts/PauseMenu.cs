using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject settingsWindow;
    public AudioClip menuClicSound;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (gameIsPaused) {
                Resume();
            } else {
                Paused();
            }
        }
    }

    void Paused() {
        AudioManager.instance.PlayClipAt(menuClicSound, transform.position);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    public void Resume() {
        AudioManager.instance.PlayClipAt(menuClicSound, transform.position);
        settingsWindow.SetActive(false);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
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
