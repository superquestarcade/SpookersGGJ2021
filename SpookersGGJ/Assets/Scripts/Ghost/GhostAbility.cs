using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAbility : MonoBehaviour
{
    public int randomDecoySound, newSound, oldSound;
    public bool ghostCD;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("GhostAbility") && ghostCD == false)
        {
            Debug.Log("Ghost ability used");
            RandomDecoySound();
            StartCoroutine("GhostCoolDown");
        }

    }

    public void RandomDecoySound()
    {
        newSound = Random.Range(1, 5);

        while (newSound == oldSound)
        {
            newSound = Random.Range(1, 5);
        }
        oldSound = newSound;
        randomDecoySound = newSound;
        Debug.Log("decoysound" + randomDecoySound);
        Debug.Log("oldsound" + oldSound);

        if (randomDecoySound == 1)
            {
                //SoundManager play the sound
                Debug.Log("#1 sound");
            }
            else if (randomDecoySound == 2)
            {
                //SoundManager play the sound
                Debug.Log("#2 sound");
            }
            else if (randomDecoySound == 3)
            {
                //SoundManager play the sound
                Debug.Log("#3 sound");
            }
            else
            {
                //SoundManager play the sound
                Debug.Log("#4 sound");
            }

    }

    IEnumerator GhostCoolDown()
    {
        ghostCD = true;
        Debug.Log(ghostCD);
        yield return new WaitForSeconds(20);
        ghostCD = false;
        Debug.Log(ghostCD);
    }

}
