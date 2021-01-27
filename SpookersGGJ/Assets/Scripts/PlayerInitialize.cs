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
    private MouseLook mouseLook;

    /// <summary>
    /// Setings
    /// </summary>

    public bool invertMouse = true;

    public Material playerSkinMaterial;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!hasAuthority) return;

        playerMovement = this.gameObject.AddComponent<PlayerMovement>();
        
        playerCamObj = Instantiate(playerCameraPrefab, this.gameObject.transform);

        mouseLook = playerCamObj.GetComponent<MouseLook>();

        mouseLook.invertYaxis = invertMouse;

        if (playerSkinMaterial != null && playerObj != null) playerObj.GetComponent<MeshRenderer>().material = playerSkinMaterial;
    }
}
