using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public float HalfTimeAfterSeconds;

    public UnityEvent OnHalfTime;
    void Start()
    {
        RunGame();
    }

    IEnumerator RunGame()
    {
        Debug.Log("GOGOGO");

        yield return new WaitForSecondsRealtime(HalfTimeAfterSeconds);

        Debug.Log("HalfTime");
        OnHalfTime.Invoke();
        SkinSwitchandSpawn();

    }

    public GameObject[] Players;
    void SkinSwitchandSpawn()
    {
        Players = GameObject.FindGameObjectsWithTag("GamePlayer");

        foreach (GameObject player in Players)
        {
            player.GetComponent<SpawnSkinner>().SwitchSkins();
        }
    }
}
