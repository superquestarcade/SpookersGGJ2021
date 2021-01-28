using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;

[DisallowMultipleComponent]
public class AudioManager : MonoBehaviour
{
    public bool debugMessages = false;
    
    public GameObject playerObj;
    
    FMOD.Studio.EventInstance levelMusic;
    public string levelMusicEventPath = "event:/music/music";
    
    FMOD.Studio.EventInstance levelAmb;
    public string levelAmbienceEventPath = "event:/sfx/amb_level";
    
    FMOD.Studio.EventInstance countdown;
    public string countdownEventPath = "event:/sfx/countdown";

    public string humanFootstepPath = "";
    
    public string ghostFootstepPath = "";
    
    public string pickupItemPath = "";
    
    public string putDownPath = "";

    public string humanFindItemPath = "";
    
    public string pingItemPath = "";
    
    public string uiButtonClickPath = "";

    // Start is called before the first frame update
    void Start()
    {
        levelMusic = FMODUnity.RuntimeManager.CreateInstance(levelMusicEventPath);
        
        levelAmb = FMODUnity.RuntimeManager.CreateInstance(levelAmbienceEventPath);
        
        countdown = FMODUnity.RuntimeManager.CreateInstance(countdownEventPath);
        
    }
    
    // Human footstep
    public void PlayHumanFootstep()
    {
        if(debugMessages) Debug.Log("Playing audio path: " + humanFootstepPath);
        FMODUnity.RuntimeManager.PlayOneShotAttached(humanFootstepPath, playerObj);
    }
    
    // Ghost footstep
    public void PlayGhostFootstep()
    {
        if(debugMessages) Debug.Log("Playing audio path: " + ghostFootstepPath);
        FMODUnity.RuntimeManager.PlayOneShotAttached(ghostFootstepPath, playerObj);
    }

    // Pickup item
    public void PlayPickupItem()
    {
        if(debugMessages) Debug.Log("Playing audio path: " + pickupItemPath);
        FMODUnity.RuntimeManager.PlayOneShotAttached(pickupItemPath, playerObj);
    }

    // Put down item
    public void PlayPutDownItem()
    {
        if(debugMessages) Debug.Log("Playing audio path: " + putDownPath);
        FMODUnity.RuntimeManager.PlayOneShotAttached(putDownPath, playerObj);
    }

    // Human find object
    public void PlayHumanFindItem()
    {
        if(debugMessages) Debug.Log("Playing audio path: " + humanFindItemPath);
        FMODUnity.RuntimeManager.PlayOneShotAttached(humanFindItemPath, playerObj);
    }

    // Ping item
    public void PlayPingItem()
    {
        if(debugMessages) Debug.Log("Playing audio path: " + pingItemPath);
        FMODUnity.RuntimeManager.PlayOneShotAttached(pingItemPath, playerObj);
    }

    // UI button click
    public void PlayUiButtonClick()
    {
        if(debugMessages) Debug.Log("Playing audio path: " + uiButtonClickPath);
        FMODUnity.RuntimeManager.PlayOneShotAttached(uiButtonClickPath, playerObj);
    }

    // Music
    public void MusicActive(bool play = true)
    {
        if (play) levelMusic.start();
        else levelMusic.stop(STOP_MODE.ALLOWFADEOUT);
    }
    
    // Ambience
    public void AmbienceActive(bool play = true)
    {
        if (play) levelAmb.start();
        else levelAmb.stop(STOP_MODE.ALLOWFADEOUT);
    }

    // Countdown
    public void CountdownActive(bool play = true)
    {
        if (play) countdown.start();
        else countdown.stop(STOP_MODE.IMMEDIATE);
    }
}
