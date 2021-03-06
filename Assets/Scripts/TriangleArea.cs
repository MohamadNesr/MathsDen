using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class TriangleArea : MonoBehaviour
{
    private float[] area = {18.0f , 25.0f};
    private float aire;
    public Animator animator;
    private bool victory = false;
    public bool game3Active;
    public bool gameOn;
    int randomInt; 

    public GameObject toDisactivate;
    public GameObject toDisactivate1;
    public GameObject toDisactivate2;
    public GameObject toDisactivate3;
    public GameObject toDisactivate4;
    public GameObject toDisactivate5;
    public GameObject victoryMessage;
    public GameObject failureMessage;

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

    Random rnd = new Random();

    private void Awake() {
        playerProfile = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerProfile>();
    }

    // Start is called before the first frame update
    private void Start() {
        playerSpawn.transform.position = newPlayerSpawn.transform.position;
        firstTipDisplayed = false;
        secondTipDisplayed = false;
        timeToCheck = Time.time;
        randomInt = rnd.Next(0, area.Length);
        aire = area[randomInt];
        toDisactivate.SetActive(false);
        toDisactivate1.SetActive(false);
        toDisactivate2.SetActive(false);
        toDisactivate3.SetActive(false);
        toDisactivate4.SetActive(false);
        toDisactivate5.SetActive(false);
        game3Active = true;    
        Debug.Log("randomInt = " + randomInt );
        Debug.Log("aire = " + aire.ToString() );
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == 7){
            if(other.gameObject.tag == "key18"  && randomInt == 0){
                victory = true;
               /* Debug.Log("Bonne valeure");
                Debug.Log(victory);*/
            }else if(other.gameObject.tag == "key25"  && randomInt == 1){
                victory = true;
               /* Debug.Log("Bonne valeure");
                Debug.Log(victory);*/
            }else{
                victory = false;
               /* Debug.Log("MauvaiseValeur");
                Debug.Log(victory);*/
            }
            
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if ((other.gameObject.tag == "key18" && randomInt == 0)||(other.gameObject.tag == "key25" && randomInt == 1)){
            victory = false;
            animator.SetBool("Area",victory);
            /*Debug.Log("ExitValeur");
            Debug.Log(victory);*/
        }
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
        gameOn = GameObject.Find("Player").GetComponent<PlayerMovement>().game3Trigger;
         if(gameOn && game3Active){
            playerProfile.timePassed[1] = Time.time - timeToCheck;
            if ((playerProfile.timePassed[1] >= 60 || playerProfile.nbErrors[1] > 0) && !firstTipDisplayed) { // A little tip maybe ?
                firstTipDisplayed = true;
                tipsText.text = "Tu te souviens de la formule de l'aire d'un triangle ? Ici, il faut multiplier la longueur de la base du triangle par sa hauteur puis diviser par 2 !";
                StartCoroutine(displayTips());
            } else if ((playerProfile.timePassed[1] > 120 || playerProfile.nbErrors[1] > 2) && !secondTipDisplayed) { // Should go back to the lesson ...
                secondTipDisplayed = true;
                tipsText.text = "Trop difficile pour l'instant ? Je te conseille d'aller revoir le cours n??2 pour revoir ce que tu n'as pas compris :)";
                StartCoroutine(displayTips());
            }
            if(randomInt == 0){
                    toDisactivate1.SetActive(true);
                    toDisactivate2.SetActive(false);
                
            } else if(randomInt == 1){
                    toDisactivate1.SetActive(false);
                    toDisactivate2.SetActive(true);
            }
            if(Input.GetKeyDown(KeyCode.T) ){
                // Increment nb essay for this exercice
                playerProfile.nbTotalEssay[1] = playerProfile.nbTotalEssay[1] + 1f;
                if(victory == true){
                    AudioManager.instance.PlayClipAt(victorySound, transform.position);
                    playerProfile.nbExercicesDone = playerProfile.nbExercicesDone + 1;
                    animator.SetBool("Area",victory);
                    Debug.Log("Partie 3 hard gagnee!");
                    Debug.Log(victory);
                    // Next difficulty computing
                    if (playerProfile.nbTotalEssay[1] < 3 && playerProfile.timePassed[1] < 120f) {
                        playerProfile.nextDifficulty = PlayerProfile.Difficulty.Hard;
                    } else {
                        playerProfile.nextDifficulty = PlayerProfile.Difficulty.Easy;
                    }
                /* Debug.Log(victory);*/
                    game3Active = false;
                    toDisactivate1.SetActive(false);
                    toDisactivate2.SetActive(false);
                    StartCoroutine( CoroutineVictory() );
                }  else{
                    AudioManager.instance.PlayClipAt(failureSound, transform.position);
                    // Increment nb errors for this exercice
                    playerProfile.nbErrors[1] = playerProfile.nbErrors[1] + 1f;
                    animator.SetBool("Area",victory);
                    StartCoroutine( CoroutineFailure() );
                    Debug.Log("Partie 3 hard perdue reessayez!");
                    //Debug.Log(victory);
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
