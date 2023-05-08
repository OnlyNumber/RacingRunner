using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NetworkPlayer : NetworkBehaviour, IPlayerLeft
{
    public static NetworkPlayer local { get; set; }

    public PlayerRef checkRef;

    [Networked] public int token { get; set; }


    public void PlayerLeft(PlayerRef player)
    {

    }

    public override void Spawned()
    {
        if(Object.HasInputAuthority)
        {
            local = this;

            Debug.Log("Spawn object");
        }
    }

    public void GetOut()
    {
            Runner.Shutdown();
    }


}
