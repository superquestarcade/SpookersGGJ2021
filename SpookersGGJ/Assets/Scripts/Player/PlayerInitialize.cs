using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerInitialize : NetworkBehaviour
{
    public GameObject playerCameraPrefab;
    public GameObject playerObj;
    
    private GameObject playerCamObj;
    private PlayerMovement playerMovement;
    private PlayerAnimation playerAnimation;
    private MouseLook mouseLook;

    /// <summary>
    /// Setings
    /// </summary>

    public bool invertMouse = true;

    public float playerSpeed = 1f;

    public Material playerSkinMaterial;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!hasAuthority) return;

        AudioManager.singleton.playerObj = this.gameObject;
        
        playerMovement = this.gameObject.AddComponent<PlayerMovement>();
        playerMovement.speed = playerSpeed;

        playerAnimation = this.GetComponentInChildren<PlayerAnimation>();

        playerAnimation.playerMovement = playerMovement;
        
        playerCamObj = Instantiate(playerCameraPrefab, this.gameObject.transform);

        mouseLook = playerCamObj.GetComponent<MouseLook>();

        mouseLook.invertYaxis = invertMouse;

        if (playerSkinMaterial != null && playerObj != null) playerObj.GetComponent<MeshRenderer>().material = playerSkinMaterial;
    }
}
