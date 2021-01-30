using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAudioFilters : MonoBehaviour
{
    private bool setFilters = true;
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!setFilters) return;
        
        AudioManager.singleton.SetAudioFilterState(AudioFilter.FOOTSTEPS, 0.5f);
        AudioManager.singleton.SetAudioFilterState(AudioFilter.PINGOBJECT, 0.5f);
        AudioManager.singleton.SetAudioFilterState(AudioFilter.PLACEOBJECT, 0.5f);
        AudioManager.singleton.SetAudioFilterState(AudioFilter.PICKUPOBJECT, 0.5f);

        setFilters = false;
    }
}
