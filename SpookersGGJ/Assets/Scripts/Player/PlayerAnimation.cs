using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerAnimation : NetworkBehaviour
{
    public Animator anim;
    public PlayerMovement playerMovement;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement != null)
        {
            anim.SetFloat("speed", Mathf.Abs(playerMovement.Velocity()*10));
            anim.SetFloat("strafe", playerMovement.Strafe*15);
            
        }
        
    }

    public void SetPlayerAnim(AnimState animState)
    {
        switch (animState)
        {
            case AnimState.WALK:
                anim.SetBool("Jog", false);
                break;
            
            case AnimState.JOG:
                anim.SetBool("Jog", true);
                break;
            
            // Place crouching
            case AnimState.PLACECROUCH:
                anim.SetTrigger("placeCrouch");

                break;
            
            // Place standing
            case AnimState.PLACESTANDING:
                anim.SetTrigger("placeStanding");

                break;
            case AnimState.LOOKBEHIND:
                anim.SetTrigger("lookBehind");

                break;

        }
        
    }

}

public enum AnimState
{
    PLACESTANDING,
    PLACECROUCH,
    LOOKBEHIND,
    WALK,
    JOG
}
