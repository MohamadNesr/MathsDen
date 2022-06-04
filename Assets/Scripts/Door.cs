using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
    private PlayerProfile playerProfile;
    public GameObject doorToDestroy;
    public GameObject doorOpenPopUp;
    public GameObject goReadLessonPopUp;
    public int lessonNeeded;
    private bool isInRange;
    public AudioClip sound;

    void Awake()
    {
        playerProfile = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerProfile>();
        isInRange = false;
    }

    void Update() {
        if (isInRange) {
            if (Input.GetKeyDown(KeyCode.E)) {
                StartCoroutine(tryOpenDoor());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        isInRange = true;
        doorOpenPopUp.SetActive(true);

    }

    private void OnTriggerExit2D(Collider2D collision) {
        isInRange = false;
        doorOpenPopUp.SetActive(false);

    }

    public IEnumerator tryOpenDoor() {
        doorOpenPopUp.SetActive(false);
        if (playerProfile.hasReadLesson[lessonNeeded]) {
            AudioManager.instance.PlayClipAt(sound, transform.position);
            Destroy(doorToDestroy);
        } else {
            goReadLessonPopUp.SetActive(true);
            yield return new WaitForSeconds(3);
            goReadLessonPopUp.SetActive(false);
            if (isInRange) {
                doorOpenPopUp.SetActive(true);
            }

        }
    }
}
