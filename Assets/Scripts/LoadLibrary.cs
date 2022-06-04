using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadLibrary : MonoBehaviour
{
    public GameObject teleportationLocation;
    public Animator fadeSystem;
    public GameObject gameButton;
    public GameObject libraryButton;
    public GameObject profileButton;
    public GameObject playerProfile;
    private GameObject player;
    public AudioClip teleportSound;

    private void Awake() {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void loadLibrary() {
        StartCoroutine(teleportThere());
    }

    public IEnumerator teleportThere() {
        AudioManager.instance.PlayClipAt(teleportSound, transform.position);
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        gameButton.SetActive(true);
        profileButton.SetActive(true);
        libraryButton.SetActive(false);
        playerProfile.SetActive(false);
        player.transform.position = teleportationLocation.transform.position;
    }
}
