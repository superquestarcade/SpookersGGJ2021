using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public NetworkLinker networkLinker;

    public Camera menuCam;
    
    public GameObject mainMenu;
    public GameObject landingPage;
    public GameObject nameInput;
    public GameObject enterIpAddress;

    public TMP_Text playerNameField;
    public TMP_Text connectionAddressField;

    private ConnectionType connect;

    // Start is called before the first frame update
    void Start()
    {
        LandingPage();
    }

    public void ButtonHostGame()
    {
        landingPage.SetActive(false);
        connect = ConnectionType.HOST;
        nameInput.SetActive(true);
    }

    public void ButtonJoinGame()
    {
        landingPage.SetActive(false);
        connect = ConnectionType.JOIN;
        nameInput.SetActive(true);
    }

    public void ButtonEnterName()
    {
        networkLinker.SetPlayerName(playerNameField.text);
        nameInput.SetActive(false);
        enterIpAddress.SetActive(true);
    }

    public void ButtonEnterIpAddress()
    {
        networkLinker.SetConnectionIP(connectionAddressField.text);

        networkLinker.Connect(connect);
        menuCam.gameObject.SetActive(false);
        mainMenu.SetActive(false);
    }

    public void LandingPage()
    {
        mainMenu.SetActive(true);
        landingPage.SetActive(true);
        nameInput.SetActive(false);
        enterIpAddress.SetActive(false);
        menuCam.gameObject.SetActive(true);
    }

}

public enum ConnectionType
{
    HOST,
    JOIN
}
