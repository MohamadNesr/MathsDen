using UnityEngine;

public class ReadingZone : MonoBehaviour
{
    private bool isInRange;
    private PlayerMovement playerMovement;
    public GameObject readingLessonText;
    public GameObject lessonContent;
    public GameObject gameButton;
    public AudioClip openLessonSound;

    private void Awake() {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    private void Update() {
        if(isInRange && Input.GetKeyDown(KeyCode.E)) {
            AudioManager.instance.PlayClipAt(openLessonSound, transform.position);
            playerMovement.isReading = true;
            lessonContent.SetActive(true);
            gameButton.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            readingLessonText.SetActive(true);
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            readingLessonText.SetActive(false);
            isInRange = false;
        }
    }
}
