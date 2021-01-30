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
        
        AudioManager.singleton.SetAudioFilterState(AudioTrigger.FOOTSTEPS, 0.5f);
        AudioManager.singleton.SetAudioFilterState(AudioTrigger.PINGOBJECT, 0.5f);
        AudioManager.singleton.SetAudioFilterState(AudioTrigger.PLACEOBJECT, 0.5f);
        AudioManager.singleton.SetAudioFilterState(AudioTrigger.PICKUPOBJECT, 0.5f);

        setFilters = false;
    }
}
