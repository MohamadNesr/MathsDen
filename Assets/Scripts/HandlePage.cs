using UnityEngine;

public class HandlePage : MonoBehaviour
{
    public GameObject[] pages;
    public GameObject buttonNext;
    private PlayerProfile playerProfile;
    public int nbPages;
    private int currentPageIndex;
    private int nextPageIndex;
    public int nbLesson;

    void Awake() {
        playerProfile = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerProfile>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentPageIndex = 0;
        nextPageIndex = 1;
        if (nbPages == 1) {
            buttonNext.SetActive(false);
        }
    }

    public void displayNextPage() {
        pages[currentPageIndex].SetActive(false);
        pages[nextPageIndex].SetActive(true);
        currentPageIndex++;
        if(currentPageIndex < nbPages - 1) {
            nextPageIndex++;
        } else {
            buttonNext.SetActive(false);
            if (nbLesson != 3) { // Safety mesure since we don't have a lesson 4 at the moment
                playerProfile.hasReadLesson[nbLesson] = true;
            }
        }
    }

    public void handleClosePage() {
        for (int i = 0 ; i < nbPages ; i++) {
            pages[i].SetActive(false);
        }
        pages[0].SetActive(true);
        currentPageIndex = 0;
        nextPageIndex = 1;
    }
}
