using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerAudio : NetworkBehaviour
{
    // this is called on the server
    [Command]
    public void CmdAudioPickup(GameObject obj)
    {
        RpcAudioPickup(obj);
    }

    // this is called on the player that triggered the sound for all observers
    [ClientRpc]
    void RpcAudioPickup(GameObject obj)
    {
        AudioManager.singleton.PlayPickupItem(obj);
    }
    
    // this is called on the server
    [Command]
    public void CmdAudioFootstep(GameObject obj)
    {
        RpcAudioFootstep(obj);
    }

    // this is called on the player that triggered the sound for all observers
    [ClientRpc]
    void RpcAudioFootstep(GameObject obj)
    {
        AudioManager.singleton.PlayHumanFootstep(obj);
    }

    
}
