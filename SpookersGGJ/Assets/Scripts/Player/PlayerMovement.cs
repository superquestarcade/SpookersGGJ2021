using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 10.0f;
    public bool slowWalk = false;
    [SerializeField] private float _velocity;

    public float Forward => _velocity; 
    
    private float strafe;
    public float Strafe => strafe;

    private PlayerAnimation playerAnimation;

    private PlayerHoldObject playerHoldObject;

    // Use this for initialization
    void Start () {
        
        // turn off the cursor
        Cursor.lockState = CursorLockMode.Locked;
        playerAnimation = GetComponent<PlayerAnimation>();
        playerHoldObject = GetComponent<PlayerHoldObject>();
    }
	
    // Update is called once per frame
    void Update () {
        // Input.GetAxis() is used to get the user's input
        // You can furthor set it on Unity. (Edit, Project Settings, Input)

        slowWalk = Input.GetButton("Shift");
        
        SetSlowWalk(slowWalk);
        
        _velocity = Input.GetAxis("Vertical") * speed * (slowWalk?0.5f:1) * Time.deltaTime;
        strafe = Input.GetAxis("Horizontal") * speed * (slowWalk?0.5f:1) * Time.deltaTime;
        transform.Translate(strafe, 0, _velocity);

        if (Input.GetKeyDown("escape")) {
            // turn on the cursor
            Cursor.lockState = CursorLockMode.None;
        }
        
        // Check animations
        if (Input.GetKeyDown(KeyCode.E))
        {
            PickUpObject();
        }
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            LookBehind();
        }
    }

    private void SetSlowWalk(bool slow)
    {
        if(playerAnimation != null) playerAnimation.SetPlayerAnim(slow?AnimState.WALK:AnimState.JOG);
    }

    private void PickUpObject()
    {
        playerHoldObject.ObjectInteract();
    }

    private void LookBehind()
    {
        if(playerAnimation != null) playerAnimation.SetPlayerAnim(AnimState.LOOKBEHIND);
    }

    public float Velocity()
    {
        return new Vector2(strafe, _velocity).magnitude;
    }
}