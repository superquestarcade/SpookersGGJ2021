using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;

[DisallowMultipleComponent]
public class AudioManager : MonoBehaviour
{
    public bool debugMessages = false;
    
    public static AudioManager singleton { get; private set; }
    public bool dontDestroyOnLoad = true;
    
    public GameObject playerObj;
    
    FMOD.Studio.EventInstance levelMusic;
    public string levelMusicEventPath = "event:/Music/InGame_Music";
    
    FMOD.Studio.EventInstance startScreenMusic;
    public string startScreenMusicEventPath = "event:/Music/SplashScreen_Music";
    
    FMOD.Studio.EventInstance levelAmb;
    public string levelAmbienceEventPath = "event:/Atmos";
    
    FMOD.Studio.EventInstance countdown;
    public string countdownEventPath = "event:/SFX/Clock";

    public string humanFootstepPath = "";
    
    public string ghostFootstepPath = "";
    
    FMOD.Studio.EventInstance pickupItem;
    public string pickupItemPath = "";
    
    public string putDownPath = "";

    public string humanFindItemPath = "";
    
    public string pingItemPath = "";
    
    public string uiButtonClickPath = "";
    public string uiButtonHoverPath = "";

    // Start is called before the first frame update
    void Start()
    {
        InitializeSingleton();
        
        levelMusic = FMODUnity.RuntimeManager.CreateInstance(levelMusicEventPath);

        startScreenMusic = FMODUnity.RuntimeManager.CreateInstance(startScreenMusicEventPath);
        
        levelAmb = FMODUnity.RuntimeManager.CreateInstance(levelAmbienceEventPath);
        
        countdown = FMODUnity.RuntimeManager.CreateInstance(countdownEventPath);

        pickupItem = FMODUnity.RuntimeManager.CreateInstance(pickupItemPath);

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
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(pickupItem, playerObj.transform, playerObj.GetComponent<Rigidbody>());
        pickupItem.start();
        pickupItem.release();
    }

    public void SetAudioFilterState(AudioFilter filter, float value)
    {
        if(debugMessages) Debug.Log($"Setting audio filter {filter} to state {value}");
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName(GetFilterAsString(filter), value, false);
    }

    private string GetFilterAsString(AudioFilter filter)
    {
        switch (filter)
        {
            case AudioFilter.FOOTSTEPS:
                return "Vol_Footsteps";
            case AudioFilter.PINGOBJECT:
                return "Vol_PingObject";
            case AudioFilter.PLACEOBJECT:
                return "Vol_PlaceObject";
            case AudioFilter.PICKUPOBJECT:
                return "Vol_PickUpObject";
        }

        return null;
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
    public void PlayUiButtonHover()
    {
        if(debugMessages) Debug.Log("Playing audio path: " + uiButtonHoverPath);
        FMODUnity.RuntimeManager.PlayOneShotAttached(uiButtonHoverPath, playerObj);
    }

    // Music
    public void LevelMusicActive(bool play = true)
    {
        ResetMusicAmbience();
        if (play) levelMusic.start();
    }
    public void StartScreenMusicActive(bool play = true)
    {
        ResetMusicAmbience();
        if (play) startScreenMusic.start();
    }
    
    // Ambience
    public void AmbienceActive(bool play = true)
    {
        if (play) levelAmb.start();
    }

    private void ResetMusicAmbience()
    {
        levelMusic.stop(STOP_MODE.ALLOWFADEOUT);
        startScreenMusic.stop(STOP_MODE.ALLOWFADEOUT);
        levelAmb.stop(STOP_MODE.ALLOWFADEOUT);
    }

    // Countdown
    public void CountdownActive(bool play = true)
    {
        if (play) countdown.start();
        else countdown.stop(STOP_MODE.IMMEDIATE);
    }
    
    bool InitializeSingleton()
    {
        if (singleton != null && singleton == this) return true;

        if (dontDestroyOnLoad)
        {
            if (singleton != null)
            {
                if(debugMessages) Debug.LogWarning("Multiple AudioManager detected in the scene. Only one AudioManager can exist at a time. The duplicate AudioManager will be destroyed.");
                Destroy(gameObject);

                // Return false to not allow collision-destroyed second instance to continue.
                return false;
            }
            if(debugMessages) Debug.Log("AudioManager created singleton (DontDestroyOnLoad)");
            singleton = this;
            if (Application.isPlaying) DontDestroyOnLoad(gameObject);
        }
        else
        {
            if(debugMessages) Debug.Log("AudioManager created singleton (ForScene)");
            singleton = this;
        }

        return true;
    }
}

public enum AudioFilter
{
    FOOTSTEPS,
    PLACEOBJECT,
    PICKUPOBJECT,
    PINGOBJECT
}
