using System.Collections;
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

    public GameObject toDesactivate;
    Random rnd = new Random();


    // Start is called before the first frame update
    private void Start() {
        randomInt = rnd.Next(0, area.Length);
        aire = area[randomInt];
        toDesactivate.SetActive(false);
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

    // Update is called once per frame
    void Update()
    {
        gameOn = GameObject.Find("Player").GetComponent<PlayerMovement>().game3Trigger;
         if(Input.GetKeyDown(KeyCode.T)&& gameOn && game3Active ){
             if(victory == true){
                animator.SetBool("Area",victory);
                Debug.Log("Partie 3 hard gagnee!");
                Debug.Log(victory);
               /* Debug.Log(victory);*/
                game3Active = false;
            }  else{
                animator.SetBool("Area",victory);
                Debug.Log("Partie 3 hard perdue reessayez!");
                //Debug.Log(victory);
            } 
         }
    }
}
