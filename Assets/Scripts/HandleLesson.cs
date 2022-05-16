using UnityEngine;

public class HandleLesson : MonoBehaviour
{
    public GameObject lessonContent;
    public GameObject gameButton;
    private PlayerMovement playerMovement;

    private void Awake() {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    public void closeLesson() {
        playerMovement.isReading = false;
        gameButton.SetActive(true);
        lessonContent.SetActive(false);
    }
}
