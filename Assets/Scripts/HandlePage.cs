using UnityEngine;

public class HandlePage : MonoBehaviour
{
    public GameObject[] pages;
    public GameObject buttonNext;
    public int nbPages;
    private int currentPageIndex;
    private int nextPageIndex;

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
