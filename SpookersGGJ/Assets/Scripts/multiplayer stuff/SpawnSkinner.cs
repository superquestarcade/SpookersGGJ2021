using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SpawnSkinner : NetworkBehaviour
{
    public player_properties playerproperties;
    public GameObject GhostSkin;
    public GameObject HumanSkin;

    GameObject tospawn;
    GameObject instantiatedskin;
    private void Start()
    {
        CmdSpawn();
    }

    [Command]
    void CmdSpawn()
    {
        
        if(playerproperties.teamID == 0)
        {
            tospawn = GhostSkin;
        }
        else
        {
            tospawn = HumanSkin;
        }

        instantiatedskin = (GameObject)Instantiate(tospawn, tospawn.transform.position, Quaternion.identity);
        //GameObject owner = this.gameObject;
        NetworkServer.Spawn(instantiatedskin, connectionToClient);
    }

    public void SwitchSkins()  // CALL AT HALFTIME OR ANYTIME TO SWITCH AND SPAWN ON SERVER AND ALL!
    {
        CmdCallServer();
    }

    [Command]
    void CmdCallServer()
    {
        DestroyOldSkin();
    }

    void DestroyOldSkin()
    {
        Destroy(instantiatedskin);
        switchTeamId();
    }

    void switchTeamId()
    {
        if (playerproperties.teamID == 0)
        {
            playerproperties.teamID = 1;
        }
        else
        {
            playerproperties.teamID = 0;
        }

        CmdSpawn();
    }
}
