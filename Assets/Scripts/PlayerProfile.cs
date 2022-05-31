using UnityEngine;
using UnityEngine.UI;

public class PlayerProfile : MonoBehaviour
{
    public enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }
    public bool [] hasReadLesson = {false, false, false};

    public int nbExercicesDone;
    public float [] nbTotalEssay = {0f, 0f};
    public float [] timePassed = {0f, 0f};
    public float [] nbErrors = {0f, 0f};
    public Difficulty nextDifficulty;

    public Text exerciceDoneTxt;
    public Text nbTryEx1;
    public Text nbTryEx2;
    public Text timePassedEx1;
    public Text timePassedEx2;
    public Text nbErrorsEx1;
    public Text nbErrorsEx2;

    void Start()
    {
        for (int i = 0 ; i < 3 ; i++) {
            hasReadLesson[i] = false;
        }
        nbExercicesDone = 0;
        nextDifficulty = Difficulty.Easy;
        for (int i = 0 ; i < 2 ; i++) {
            nbTotalEssay[i] = 0f;
        }
        for (int i = 0 ; i < 2 ; i++) {
            timePassed[i] = 0f;
        }
        for (int i = 0 ; i < 2 ; i++) {
            nbErrors[i] = 0f;
        }
    }

    void Update() {
        exerciceDoneTxt.text = nbExercicesDone.ToString();
        nbTryEx1.text = nbTotalEssay[0].ToString();
        nbTryEx2.text = nbTotalEssay[1].ToString();
        timePassedEx1.text = timePassed[0].ToString() + " Sec";
        timePassedEx2.text = timePassed[1].ToString() + " Sec";
        nbErrorsEx1.text = nbErrors[0].ToString();
        nbErrorsEx2.text = nbErrors[1].ToString();
    }

}
