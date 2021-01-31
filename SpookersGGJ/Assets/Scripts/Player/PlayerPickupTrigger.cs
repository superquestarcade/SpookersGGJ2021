using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerPickupTrigger : MonoBehaviour
{
    public PlayerHoldObject playerHoldObject;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            playerHoldObject.ObjectInReach(other.gameObject, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            playerHoldObject.ObjectInReach(other.gameObject, false);
        }
    }
}
