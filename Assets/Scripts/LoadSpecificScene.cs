using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadSpecificScene : MonoBehaviour
{
    public string sceneName;
    public Animator fadeSystem;
    public GameObject gameButton;
    public GameObject libraryButton;

    private void Awake() {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }

    public void loadScene() {
        StartCoroutine(loadNextScene());
    }

    public IEnumerator loadNextScene() {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        if(sceneName == "LibraryScene") {
            gameButton.SetActive(true);
            libraryButton.SetActive(false);
        } else if (sceneName == "GameScene") {
            gameButton.SetActive(false);
            libraryButton.SetActive(true);
        }
        SceneManager.LoadScene(sceneName);
    }
}
