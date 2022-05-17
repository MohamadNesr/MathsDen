using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpInstructions : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public GameObject pickUpText;
   // pickUpText
    private void Awake() {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
       // pickUpText = GameObject.FindGameObjectWithTag("AppleText");
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            pickUpText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            pickUpText.SetActive(false);
        }
    }


}
