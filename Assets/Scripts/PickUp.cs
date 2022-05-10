using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform holdSpot;
    public LayerMask pickUpMask;
    public LayerMask pickUpMask2;
    public Vector3 Direction { get; set;}
    private GameObject itemHolding;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            if (itemHolding){
                itemHolding.transform.position = transform.position + Direction;
                itemHolding.transform.parent = null;
                if (itemHolding.GetComponent<Rigidbody2D>())
                        itemHolding.GetComponent<Rigidbody2D>().simulated = true;
                itemHolding= null;
            }else{
                Collider2D  pickUpItem = Physics2D.OverlapCircle(transform.position + Direction, .4f, pickUpMask);
                if(pickUpItem){
                    itemHolding = pickUpItem.gameObject;
                    itemHolding.transform.position = holdSpot.position;
                    itemHolding.transform.parent = transform;
                    if (itemHolding.GetComponent<Rigidbody2D>())
                        itemHolding.GetComponent<Rigidbody2D>().simulated = false;
                }
            }
        }
    }
}
