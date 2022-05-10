using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomArea : MonoBehaviour
{
    public int area = 81;
    public Animator animator;
    private bool victory = false;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == 7){
            if(other.gameObject.tag == "key81"){
                victory = true;
                Debug.Log("Bonne valeure");
                Debug.Log(victory);
            }else{
                victory = false;
                Debug.Log("MauvaiseValeur");
                Debug.Log(victory);
            }
            
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "key81"){
            victory = false;
            animator.SetBool("Area",victory);
            Debug.Log("ExitValeur");
            Debug.Log(victory);
        }
    }    

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.T)){
             if(victory == true){
                animator.SetBool("Area",victory);
                Debug.Log("Partie gagnee!");
                Debug.Log(victory);
            }  else{
                animator.SetBool("Area",victory);
                Debug.Log("Partie perdue reessayez!");
                Debug.Log(victory);
            } 
         }
    }
}
