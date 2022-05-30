using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class RoomArea : MonoBehaviour
{
    private float[] area = {64.0f, 81.0f, 100.0f};
    private float aire;
    public Animator animator;
    private bool victory = false;
    public bool game3Active;
    public bool gameOn;
    public int randomInt; 
    public GameObject toDisactivate;
    public GameObject toDisactivate1;
    public GameObject toDisactivate2;
    public GameObject toDisactivate3;
    public GameObject toDisactivate4;
    public GameObject toDisactivate5;


    Random rnd = new Random();


    // Start is called before the first frame update
    private void Start() {

        randomInt = rnd.Next(0, area.Length);
        aire = area[randomInt];
        Debug.Log("randomInt = " + randomInt );
        Debug.Log("aire = " + aire.ToString() );
        //-----------------WILL BE DELETED WHEN USER PROFILE IS SET------------------
        toDisactivate.SetActive(false);
        toDisactivate4.SetActive(false);
        toDisactivate5.SetActive(false);
        //----------------------------------------------------------------------------
        toDisactivate1.SetActive(false);
        toDisactivate2.SetActive(false);
        toDisactivate3.SetActive(false);
        game3Active = true;    
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == 7){
            if(other.gameObject.tag == "key81" && randomInt == 1){
                victory = true;
               /* Debug.Log("Bonne valeure");
                Debug.Log(victory);*/
            }else if(other.gameObject.tag == "key64" && randomInt == 0){
                victory = true;
               /* Debug.Log("Bonne valeure");
                Debug.Log(victory);*/
            }else if(other.gameObject.tag == "key100" && randomInt == 2){
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
        if ((other.gameObject.tag == "key81" &&  randomInt == 1) ||
        (other.gameObject.tag == "key64" &&  randomInt == 0 )||
        (other.gameObject.tag == "key100" &&  randomInt == 2)){
            victory = false;
            animator.SetBool("Area",victory);
            /*Debug.Log("ExitValeur");
            Debug.Log(victory);*/
        }
    }    

    // Update is called once per frame
    void Update()
    {
        gameOn = GameObject.Find("Player").GetComponent<PlayerMovement>().game3Trigger;
          if(gameOn && game3Active){
            if(randomInt == 0){
                    toDisactivate1.SetActive(true);
                    toDisactivate2.SetActive(false);
                    toDisactivate3.SetActive(false);
                
            } else if(randomInt == 1){
                    toDisactivate1.SetActive(false);
                    toDisactivate2.SetActive(true);
                    toDisactivate3.SetActive(false);
            } else if(randomInt ==2){
                    toDisactivate1.SetActive(false);
                    toDisactivate2.SetActive(false);
                    toDisactivate3.SetActive(true);
            }
            if(Input.GetKeyDown(KeyCode.T)){
                if(victory == true){
                    animator.SetBool("Area",victory);
                    Debug.Log("Partie 3 gagnee!");
                    game3Active = false;
                    toDisactivate1.SetActive(false);
                    toDisactivate2.SetActive(false);
                    toDisactivate3.SetActive(false);
                }  else{
                    animator.SetBool("Area",victory);
                    Debug.Log("Partie 3 perdue reessayez!");
                } 
            }
         }
    }
}
