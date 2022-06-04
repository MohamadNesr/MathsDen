using UnityEngine;

public class HandleLesson : MonoBehaviour
{
    public GameObject lessonContent;
    public GameObject gameButton;
    public GameObject buttonNext;
    private PlayerMovement playerMovement;
    public int nbPages;
    public AudioClip closeSound;

    private void Awake() {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    public void closeLesson() {
        AudioManager.instance.PlayClipAt(closeSound, transform.position);
        playerMovement.isReading = false;
        gameButton.SetActive(true);
        if (nbPages != 1) {
            buttonNext.SetActive(true);
        }
        lessonContent.SetActive(false);
    }
}
