using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMusic : MonoBehaviour
{
    private bool shouldStart = true;
    private bool menuMusic = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!shouldStart) return;
        
        
        AudioManager.singleton.LevelMusicActive(true);
        AudioManager.singleton.AmbienceActive(true);

        shouldStart = false;
    }
}
