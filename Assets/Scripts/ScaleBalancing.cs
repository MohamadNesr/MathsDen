using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;



public class ScaleBalancing : MonoBehaviour
{
    // number of objects on the scale
    private int nb_objects = 0;
    // weight required on scale baguette {150.5, 180.25}
    private float[] weight = {903.0f, 721.0f };
    // weight of one apple
    private float[] objectWeight = {150.5f, 180.25f};

    //weight of baguette
    private float baguetteWeight;

    // total weight of objects on the scale
    private float w;
    private float ow;
    private float totalWeight = 0.0f;
    public Animator animator;
    Random rnd = new Random();
    public int randomInt; 
    public bool game1Active;
    public bool gameOn;
    private int scaleBalance = 1;
    public GameObject toDisactivate1;
    public GameObject toDisactivate2;
    public GameObject victoryDoorToDestroy;
    
    // PlayerProfile reference
    private PlayerProfile playerProfile;
    private float timeToCheck;

    // Next game difficulties
    public GameObject nextGameEasy;
    public GameObject nextGameHard;

    private void Awake() {
        playerProfile = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerProfile>();
    }

    private void Start() {
        game1Active = true;
        timeToCheck = Time.time;
        randomInt = rnd.Next(0, weight.Length);
        w = weight[randomInt];
        ow = objectWeight[randomInt];
        baguetteWeight = w/5;
        toDisactivate1.SetActive(false);
        toDisactivate2.SetActive(false);
        Debug.Log("Poids objet:" + ow);
        Debug.Log("Poids total: " + w);
    
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if ((other.gameObject.tag == "Spawnable")&& (other.GetType() == typeof(BoxCollider2D))){
            nb_objects++;
        }
        /* Debug.Log(nb_objects);
        Debug.Log(nb_objects*objectWeight);
        Debug.Log(weight);*/
    }  
    private void OnTriggerExit2D(Collider2D other) {
        if ((other.gameObject.tag == "Spawnable")&& (other.GetType() == typeof(BoxCollider2D))){
            nb_objects--;
        }
       /* Debug.Log(nb_objects);
        Debug.Log(nb_objects*objectWeight);
        Debug.Log(weight);*/
    }    
    

    // Update is called once per frame
    void Update()
    {
        // Update time passed since begining of exercice in seconds
        playerProfile.timePassed[0] = Time.time - timeToCheck;
        gameOn = GameObject.Find("Player").GetComponent<PlayerMovement>().game1Trigger;
        totalWeight = nb_objects*ow;
        animator.SetInteger("scaleBalance", scaleBalance);
        if(w<totalWeight){
            scaleBalance=-1;
        }else if(w == totalWeight){
            scaleBalance=0;
        }else{
            scaleBalance = 1;
        }
        if(gameOn && game1Active){
            if(randomInt == 0){
                    toDisactivate1.SetActive(true);
                    toDisactivate2.SetActive(false);
                
            } else if(randomInt == 1){
                    toDisactivate1.SetActive(false);
                    toDisactivate2.SetActive(true);
            }
            if(Input.GetKeyDown(KeyCode.T)){
                // Increment nb essay for this exercice
                playerProfile.nbTotalEssay[0] = playerProfile.nbTotalEssay[0] + 1f;
                if(totalWeight.ToString() == w.ToString() ){
                    toDisactivate1.SetActive(false);
                    toDisactivate2.SetActive(false);
                    Debug.Log("Partie 1 gagnee!");
                    playerProfile.nbExercicesDone = playerProfile.nbExercicesDone + 1;
                    // Next difficulty computing
                    if (playerProfile.nbTotalEssay[0] < 3 && playerProfile.timePassed[0] < 120f) {
                        playerProfile.nextDifficulty = PlayerProfile.Difficulty.Hard;
                        nextGameEasy.SetActive(false);
                        nextGameHard.SetActive(true);
                    } else {
                        playerProfile.nextDifficulty = PlayerProfile.Difficulty.Easy;
                        nextGameEasy.SetActive(true);
                        nextGameHard.SetActive(false);
                    }
                    
                    // Open new path
                    Destroy(victoryDoorToDestroy);
                    game1Active = false;
                }  else{
                    // Increment nb errors for this exercice
                    playerProfile.nbErrors[0] = playerProfile.nbErrors[0] + 1f;
                    Debug.Log("Partie 1 perdue reessayez!");
                } 
            }
        }
        
    }
}
