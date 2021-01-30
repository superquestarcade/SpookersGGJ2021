using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAudioSliders : MonoBehaviour
{
    public void SetFootstepAudioState(float value)
    {
        AudioManager.singleton.SetAudioFilterState(AudioTrigger.FOOTSTEPS, value);
    }
    
    public void SetPlaceItemAudioState(float value)
    {
        AudioManager.singleton.SetAudioFilterState(AudioTrigger.PLACEOBJECT, value);
    }
    
    public void SetPickUpAudioState(float value)
    {
        AudioManager.singleton.SetAudioFilterState(AudioTrigger.PICKUPOBJECT, value);
    }
    
    public void SetPingAudioState(float value)
    {
        AudioManager.singleton.SetAudioFilterState(AudioTrigger.PINGOBJECT, value);
    }
}
