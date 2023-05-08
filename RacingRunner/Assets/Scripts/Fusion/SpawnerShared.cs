using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class SpawnerShared : SimulationBehaviour, IPlayerJoined
{
    // Start is called before the first frame update
    public NetworkPlayer playerPrefab;


    public void PlayerJoined(PlayerRef player)
    {
        if (player == Runner.LocalPlayer)
        {
            //Debug.Log("Poshel nahui");
            Runner.Spawn(playerPrefab, new Vector3(0, 1, 0), Quaternion.identity, player);
        }
    }
}
