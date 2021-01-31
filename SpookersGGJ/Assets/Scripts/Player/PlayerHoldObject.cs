using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHoldObject : MonoBehaviour
{
    public bool debugMessages = false;

    public PlayerAnimation playerAnimation;
    public float pickupAnimationDelay = 1f;
    
    public GameObject objectInHand;
    public Transform placeObjectHere;
    
    private GameObject objectOnGround;
    
    [SerializeField] private bool holdingObject = false;

    [SerializeField] private bool canPickUpObject = false;

    // Audio
    public AudioManager audioManager;

    // Update is called once per frame
    void Update()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
    }

    public void ObjectInteract()
    {
        if (!holdingObject && canPickUpObject)
        {
            canPickUpObject = false;
            holdingObject = true;
        
            AudioManager.singleton.PlayPickupItem();
            if(playerAnimation != null) playerAnimation.SetPlayerAnim(AnimState.PLACECROUCH);

            StartCoroutine(DelayPickupObject(pickupAnimationDelay));
            
            if (debugMessages) Debug.Log($"Picked up object");
            
            return;
        }
        
        if(holdingObject)
        {
            holdingObject = false;
            canPickUpObject = false;
        
            AudioManager.singleton.PlayPutDownItem();
            if(playerAnimation != null) playerAnimation.SetPlayerAnim(AnimState.PLACECROUCH);
            
            StartCoroutine(DelayPlaceObject(pickupAnimationDelay));
            
            if (debugMessages) Debug.Log($"Placed object");
            
            return;
        }
        
        if (debugMessages) Debug.Log($"Not holding object");
    }
    
    public void ObjectInReach(GameObject pickupObject, bool canReach = false)
    {
        objectOnGround = (canReach ? pickupObject:null);
        canPickUpObject = canReach;
        if(debugMessages) Debug.Log($"Object {pickupObject.name} {(canReach?"within ":"out of ")} reach");
    }

    private IEnumerator DelayPickupObject(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        objectOnGround.SetActive(false);
        objectInHand.SetActive(true);
        
    }
    
    private IEnumerator DelayPlaceObject(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        
        objectOnGround.transform.position = placeObjectHere.position;
        objectOnGround.transform.rotation = placeObjectHere.rotation;
        objectOnGround.SetActive(true);
        objectInHand.SetActive(false);

    }
}
