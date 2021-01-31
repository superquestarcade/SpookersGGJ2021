using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtons: MonoBehaviour
{
    public GameObject mainMenu, settingPanel, joinGamePanel, lobbyHost, lobbyGuest; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Settings()
    {
        settingPanel.SetActive(true);
    }

    public void ExitSettings()
    {
        settingPanel.SetActive(false);
    }

    public void JoinGame()
    {
        joinGamePanel.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void LobbyHost()
    {
        lobbyHost.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void LobbyGuest()
    {
        lobbyGuest.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void BacktoMM()
    {
        lobbyGuest.SetActive(false);
        lobbyHost.SetActive(false);
        joinGamePanel.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void BacktoJoinGame()
    {
        lobbyGuest.SetActive(false);
        joinGamePanel.SetActive(true);
    }
}
