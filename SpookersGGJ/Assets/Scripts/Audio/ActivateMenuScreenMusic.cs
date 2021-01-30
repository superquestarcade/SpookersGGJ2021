using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMenuScreenMusic : MonoBehaviour
{
    private bool activate = true;

    // Update is called once per frame
    void LateUpdate()
    {
        if(!activate) return;
        
        AudioManager.singleton.StartScreenMusicActive(true);

        activate = false;
    }
}
