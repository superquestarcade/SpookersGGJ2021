using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameManager : MonoBehaviour
{
    public NetworkManager netManager;
    private string playerName;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetConnectionIP(string newIP)
    {
        netManager.networkAddress = newIP;
    }

    public void SetPlayerName(string name)
    {
        playerName = name;
        Debug.Log($"Set player name: {name}");
    }

    public void Connect(ConnectionType newConnectionType)
    {
        switch (newConnectionType)
        {
            case ConnectionType.HOST:
                Debug.Log("Hosting server");
                netManager.StartHost();

                break;
            case ConnectionType.JOIN:
                Debug.Log($"Connecting to host: {netManager.networkAddress}");
                netManager.StartClient();

                break;
        }
    }
}
