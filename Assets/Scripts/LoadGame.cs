using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    public GameObject teleportationLocation;
    public Animator fadeSystem;
    public GameObject gameButton;
    public GameObject libraryButton;
    public GameObject profileButton;
    public GameObject playerProfile;
    private GameObject player;

    private void Awake() {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void loadGame() {
        StartCoroutine(teleportThere());
    }

    public IEnumerator teleportThere() {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        gameButton.SetActive(false);
        profileButton.SetActive(true);
        libraryButton.SetActive(true);
        playerProfile.SetActive(false);
        player.transform.position = teleportationLocation.transform.position;
    }
}
