using UnityEngine;

public class HandleLesson : MonoBehaviour
{
    public GameObject lessonContent;
    public GameObject gameButton;
    public GameObject buttonNext;
    private PlayerMovement playerMovement;
    public int nbPages;

    private void Awake() {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    public void closeLesson() {
        playerMovement.isReading = false;
        gameButton.SetActive(true);
        if (nbPages != 1) {
            buttonNext.SetActive(true);
        }
        lessonContent.SetActive(false);
    }
}
