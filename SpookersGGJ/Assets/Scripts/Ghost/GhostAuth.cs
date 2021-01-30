using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GhostAuth : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!hasAuthority) return;
        this.gameObject.AddComponent<GhostAbility>();
    }
}
