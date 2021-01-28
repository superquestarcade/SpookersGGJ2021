using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class player_properties : NetworkBehaviour
{
    [SyncVar]public string name;

    [SyncVar, Range(0,1)] //just two teams
    public int teamID;
}
