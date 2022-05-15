using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadSpecificScene : MonoBehaviour
{
    public GameObject teleportationLocation;
    public Animator fadeSystem;
    public GameObject gameButton;
    public GameObject libraryButton;
    private GameObject player;
    private bool isGame;

    private void Awake() {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        isGame = true;
    }

    public void loadScene() {
        StartCoroutine(teleportThere());
    }

    public IEnumerator teleportThere() {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        if(isGame) {
            gameButton.SetActive(true);
            libraryButton.SetActive(false);
            isGame = false;
        } else if (!isGame) {
            gameButton.SetActive(false);
            libraryButton.SetActive(true);
            isGame = true;
        }
        player.transform.position = teleportationLocation.transform.position;
    }
}
