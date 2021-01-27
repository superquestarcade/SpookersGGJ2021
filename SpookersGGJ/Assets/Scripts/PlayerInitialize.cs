using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerInitialize : NetworkBehaviour
{
    public GameObject playerCameraPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!hasAuthority) return;

        this.gameObject.AddComponent<PlayerMovement>();
        Instantiate(playerCameraPrefab, this.gameObject.transform);
    }
}
