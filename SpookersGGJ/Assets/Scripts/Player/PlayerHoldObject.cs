using System;
using UnityEngine;


public class PlayerHoldObject : MonoBehaviour
{
    public Transform objectHoldPoint;
    private GameObject objectToHold;
    private bool holdingObject = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (holdingObject && objectToHold != null)
        {
            objectToHold.transform.position = objectHoldPoint.position;
            objectToHold.transform.rotation = objectHoldPoint.rotation;
        }
    }
    
    public void PickupObject(GameObject obj)
    {
        objectToHold = obj;
        holdingObject = true;
    }

    public void Placebject()
    {
        holdingObject = false;
        objectToHold = null;
    }
}
