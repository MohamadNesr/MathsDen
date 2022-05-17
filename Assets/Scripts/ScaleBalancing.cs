using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBalancing : MonoBehaviour
{
    // number of objects on the scale
    private int nb_objects = 0;
    // weight required on scale
    public float weight = 12.6f;
    // weight of one object
    public float objectWeight = 4.2f;
    // total weight of objects on the scale
    private float totalWeight = 0.0f;
    public Animator animator;

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
        totalWeight = nb_objects*objectWeight;
        animator.SetFloat("objWeight", totalWeight);
        animator.SetFloat("weight", weight);
        if(Input.GetKeyDown(KeyCode.T)){
            if(totalWeight.ToString() == weight.ToString()){
                Debug.Log("Partie gagnee!");
            }  else{
                Debug.Log("Partie perdue reessayez!");
            } 
        }
    }
}
