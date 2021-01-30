using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFaders : MonoBehaviour
{
    FMOD.Studio.Bus Footstep;
    FMOD.Studio.Bus Ping;
    FMOD.Studio.Bus PickUp;
    FMOD.Studio.Bus Drop;
    float FootstepVol = 0.5f;
    float PingVol = 0.5f;
    float PickupVol = 0.5f;
    float DropVol = 0.5f;
    
    void Awake()
    {
        Footstep = FMODUnity.RuntimeManager.GetBus ("bus:/SFX/Ghost/G_Footstep");
        Ping = FMODUnity.RuntimeManager.GetBus ("bus:/SFX/Ghost/G_ObjectPings");
        PickUp = FMODUnity.RuntimeManager.GetBus ("bus:/SFX/Ghost/G_PickUpObject");
        Drop = FMODUnity.RuntimeManager.GetBus ("bus:/SFX/Ghost/G_PlaceDropObject");
    }

    // Update is called once per frame
    void Update()
    {
        Footstep.setVolume (FootstepVol);
        Ping.setVolume (PingVol);
        PickUp.setVolume (PickupVol);
        Drop.setVolume (DropVol);
    }

    public void FootstepVolLevel (float newFootstepVol)
    {
        FootstepVol = newFootstepVol;
    }

    public void PingVolLevel (float newPingVol)
    {
        PingVol = newPingVol;
    }

    public void PickupVolLevel (float newPickupVol)
    {
        PickupVol = newPickupVol;
    }

    public void DropVolLevel (float newDropVol)
    {
        DropVol = newDropVol; 
    }

}
