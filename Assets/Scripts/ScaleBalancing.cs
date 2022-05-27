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

    private void Start() {
        game1Active = true;
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
                if(totalWeight.ToString() == w.ToString() ){
                    toDisactivate1.SetActive(false);
                    toDisactivate2.SetActive(false);
                    Debug.Log("Partie 1 gagnee!");
                    game1Active = false;
                }  else{
                    Debug.Log("Partie 1 perdue reessayez!");
                } 
            }
        }
        
    }
}
