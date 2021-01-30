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
    public string levelMusicEventPath = "event:/Music/InGame_Music";
    FMOD.Studio.EventInstance startScreenMusic;
    public string startScreenMusicEventPath = "event:/Music/SplashScreen_Music";
    
    FMOD.Studio.EventInstance levelAmb;
    public string levelAmbienceEventPath = "event:/Atmos";
    
    FMOD.Studio.EventInstance countdown;
    public string countdownEventPath = "event:/SFX/Clock";

    FMOD.Studio.EventInstance humanFootstep;
    public string humanFootstepPath = "";
    
    FMOD.Studio.EventInstance ghostFootstep;
    public string ghostFootstepPath = "";
    
    FMOD.Studio.EventInstance pickupItem;
    public string pickupItemPath = "";
    
    FMOD.Studio.EventInstance putDownItem;
    public string putDownPath = "";

    public string humanFindItemPath = "";
    
    FMOD.Studio.EventInstance pingItem;
    public string pingItemPath = "";
    
    public string uiButtonClickPath = "";
    public string uiButtonHoverPath = "";

    // Start is called before the first frame update
    void Start()
    {
        levelMusic = FMODUnity.RuntimeManager.CreateInstance(levelMusicEventPath);

        startScreenMusic = FMODUnity.RuntimeManager.CreateInstance(startScreenMusicEventPath);
        
        levelAmb = FMODUnity.RuntimeManager.CreateInstance(levelAmbienceEventPath);
        
        countdown = FMODUnity.RuntimeManager.CreateInstance(countdownEventPath);

        pickupItem = FMODUnity.RuntimeManager.CreateInstance(pickupItemPath);

        ghostFootstep = FMODUnity.RuntimeManager.CreateInstance(ghostFootstepPath);

        putDownItem = FMODUnity.RuntimeManager.CreateInstance(putDownPath);

        pingItem = FMODUnity.RuntimeManager.CreateInstance(pingItemPath);

        humanFootstep = FMODUnity.RuntimeManager.CreateInstance(humanFootstepPath);
        
    }
    
    // Human footstep
    public void PlayHumanFootstep()
    {
        if(debugMessages) Debug.Log("Playing audio path: " + humanFootstepPath);
        //FMODUnity.RuntimeManager.PlayOneShotAttached(humanFootstepPath, playerObj);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(humanFootstep, transform, GetComponent<Rigidbody>());
        //FMODUnity.RuntimeManager.StudioSystem.setParameterByName("HumanFootstepMaterial", FootstepMaterial);
        humanFootstep.start();
    }
    
    // Ghost footstep
    public void PlayGhostFootstep()
    {
        if(debugMessages) Debug.Log("Playing audio path: " + ghostFootstepPath);
        //FMODUnity.RuntimeManager.PlayOneShotAttached(ghostFootstepPath, playerObj);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(ghostFootstep, transform, GetComponent<Rigidbody>());
        ghostFootstep.start();
    }

    // Pickup item
    public void PlayPickupItem()
    {
        if(debugMessages) Debug.Log("Playing audio path: " + pickupItemPath);
        //FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Vol_PickUpObject", audioFilterState, false);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(pickupItem, transform, GetComponent<Rigidbody>());
        pickupItem.start();
        pickupItem.release();
    }

    // Put down item
    public void PlayPutDownItem()
    {
        if(debugMessages) Debug.Log("Playing audio path: " + putDownPath);
        //FMODUnity.RuntimeManager.PlayOneShotAttached(putDownPath, playerObj);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(putDownItem, transform, GetComponent<Rigidbody>());
        putDownItem.start();
        putDownItem.release();
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
        //FMODUnity.RuntimeManager.PlayOneShotAttached(pingItemPath, playerObj);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(pingItem, transform, GetComponent<Rigidbody>());
        pingItem.start();
        pingItem.release();
    }

    // UI button click
    public void PlayUiButtonClick()
    {
        if(debugMessages) Debug.Log("Playing audio path: " + uiButtonClickPath);
        FMODUnity.RuntimeManager.PlayOneShotAttached(uiButtonClickPath, playerObj);
    }
    public void PlayUiButtonHover()
    {
        if(debugMessages) Debug.Log("Playing audio path: " + uiButtonHoverPath);
        FMODUnity.RuntimeManager.PlayOneShotAttached(uiButtonHoverPath, playerObj);
    }

    // Music
    public void LevelMusicActive(bool play = true)
    {
        if (play) levelMusic.start();
        else levelMusic.stop(STOP_MODE.ALLOWFADEOUT);
    }
    public void StartScreenMusicActive(bool play = true)
    {
        if (play) startScreenMusic.start();
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
        if (play) 
        {
            //FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Countdown", clockTime);
            countdown.start();
        }
        else countdown.stop(STOP_MODE.IMMEDIATE);
    }
}
