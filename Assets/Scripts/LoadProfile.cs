using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadProfile : MonoBehaviour
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

    public void loadProfile() {
        StartCoroutine(teleportThere());
    }

    public IEnumerator teleportThere() {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        gameButton.SetActive(true);
        libraryButton.SetActive(true);
        profileButton.SetActive(false);
        player.transform.position = teleportationLocation.transform.position;
        playerProfile.SetActive(true);
    }
}
