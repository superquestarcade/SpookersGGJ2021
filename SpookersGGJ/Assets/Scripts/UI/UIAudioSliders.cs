using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAudioSliders : MonoBehaviour
{
    public Slider sliderFootsteps;
    public Slider sliderPlaceItem;
    public Slider sliderPickUp;
    public Slider sliderPing;

    public int maxPoints = 200;
    public int pointPool = 0;
    
    public void BalanceSliders(AudioTrigger trigger, float value)
    {
        if (TotalPoints() > maxPoints)
        {
            
        }
    }
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

    int TotalPoints()
    {
        int points = 0;

        if (sliderFootsteps.value <= 0.5) points += Mathf.FloorToInt(sliderFootsteps.value * 100);
        else points += 50 + Mathf.FloorToInt((sliderFootsteps.value-0.5f) * 100);
        
        if (sliderPlaceItem.value <= 0.5) points += Mathf.FloorToInt(sliderPlaceItem.value * 100);
        else points += 50 + Mathf.FloorToInt((sliderPlaceItem.value-0.5f) * 100);
        
        if (sliderPickUp.value <= 0.5) points += Mathf.FloorToInt(sliderPickUp.value * 100);
        else points += 50 + Mathf.FloorToInt((sliderPickUp.value-0.5f) * 100);
        
        if (sliderPing.value <= 0.5) points += Mathf.FloorToInt(sliderPing.value * 100);
        else points += 50 + Mathf.FloorToInt((sliderPing.value-0.5f) * 100);

        return points;
    }
}
