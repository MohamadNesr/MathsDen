using UnityEngine;

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

}
