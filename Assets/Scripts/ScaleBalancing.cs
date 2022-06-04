using System.Collections;
using UnityEngine.UI;
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
    public GameObject victoryMessage;
    public GameObject failureMessage;
    public GameObject victoryDoorToDestroy;
    
    // PlayerProfile reference
    private PlayerProfile playerProfile;
    private float timeToCheck;

    // PlayerSpawn reference
    public GameObject playerSpawn;
    // New PlayerSpawn reference
    public GameObject newPlayerSpawn;

    // tips text reference
    public GameObject tipsPanel;
    public Text tipsText;
    private bool firstTipDisplayed;
    private bool secondTipDisplayed;

    // Sounds
    public AudioClip failureSound;
    public AudioClip victorySound;

    // Next game difficulties
    public GameObject nextGameEasy;
    public GameObject nextGameHard;

    private void Awake() {
        playerProfile = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerProfile>();
    }

    private void Start() {
        playerSpawn.transform.position = newPlayerSpawn.transform.position;
        game1Active = true;
        firstTipDisplayed = false;
        secondTipDisplayed = false;
        timeToCheck = Time.time;
        randomInt = rnd.Next(0, weight.Length);
        w = weight[randomInt];
        ow = objectWeight[randomInt];
        baguetteWeight = w/5;
        toDisactivate1.SetActive(false);
        toDisactivate2.SetActive(false);
        victoryMessage.SetActive(false);
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
    
    IEnumerator CoroutineVictory(){
        victoryMessage.SetActive(true);
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3.0f);
        victoryMessage.SetActive(false);
    }
    IEnumerator CoroutineFailure(){
        failureMessage.SetActive(true);
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3.0f);
        failureMessage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
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
            // Update time passed since begining of exercice in seconds
            playerProfile.timePassed[0] = Time.time - timeToCheck;
            if ((playerProfile.timePassed[0] >= 60 || playerProfile.nbErrors[0] > 0) && !firstTipDisplayed) { // A little tip maybe ?
                firstTipDisplayed = true;
                tipsText.text = "Tu te souviens du tableau de proportionnalité ? Ici, il faut en faire un pour le pain et un pour les pommes, puis regarder quelle quantité correspond au même poids !";
                StartCoroutine(displayTips());
            } else if ((playerProfile.timePassed[0] > 120 || playerProfile.nbErrors[0] > 2) && !secondTipDisplayed) { // Should go back to the lesson ...
                secondTipDisplayed = true;
                tipsText.text = "Trop difficile pour l'instant ? Je te conseille d'aller revoir le cours n°1 pour revoir ce que tu n'as pas compris :)";
                StartCoroutine(displayTips());
            }
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
                    AudioManager.instance.PlayClipAt(victorySound, transform.position);
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
                    StartCoroutine( CoroutineVictory() );
                    game1Active = false;
                }  else{
                    AudioManager.instance.PlayClipAt(failureSound, transform.position);
                    // Increment nb errors for this exercice
                    playerProfile.nbErrors[0] = playerProfile.nbErrors[0] + 1f;
                    StartCoroutine( CoroutineFailure() );
                    Debug.Log("Partie 1 perdue reessayez!");
                } 
            }
        }
        
    }

    public IEnumerator displayTips() {
        tipsPanel.SetActive(true);
        yield return new WaitForSeconds(10);
        tipsPanel.SetActive(false);
    }
}
