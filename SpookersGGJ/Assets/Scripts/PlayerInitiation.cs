using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
/// <summary>
/// Change color of local player.
/// Enable Components only on LocalPlayer
/// Ser name to Local
/// </summary>
//szsahaj www.embracingearth.space
public class PlayerInitiation : NetworkBehaviour
{
    public MeshRenderer[] meshrenderes;

    [SerializeField,Tooltip("Components to Disable if LocalPlayer")]
    private Behaviour[] ComponentstoEnable;

    public override void OnStartAuthority()
    {
        //Components to Disable if LocalPlayer
        for(int i =0; i < ComponentstoEnable.Length; i++)
        {
            ComponentstoEnable[i].enabled = true;
        }

        //Change Color if its Local Player
        for (int i =0; i < meshrenderes.Length; i++)
        {
            meshrenderes[i].material.color = Color.white;
        }

        //Change Name to Local to access easily  
        this.gameObject.name = ("Local");

    }

    private void Start()
    {
        for (int i = 0; i < ComponentstoEnable.Length; i++)
        {
            ComponentstoEnable[i].enabled = false;
        }
    }
    
}
