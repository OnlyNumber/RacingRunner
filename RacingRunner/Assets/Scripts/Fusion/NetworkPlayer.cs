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
        else
        {
            /*Camera localCamera = GetComponentInChildren<Camera>();
            localCamera.enabled = false;

            AudioListener localAudioListener = GetComponentInChildren<AudioListener>();
            localAudioListener.enabled = false;*/
        }

    }

    public void GetOut()
    {
            Runner.Shutdown();
    }


}
