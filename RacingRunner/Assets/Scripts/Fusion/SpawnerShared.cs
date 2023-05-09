using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class SpawnerShared : SimulationBehaviour, IPlayerJoined
{
    // Start is called before the first frame update
    public NetworkPlayer playerPrefab;

    
    private GameStarter gameStarter;

    private void Start()
    {
        gameStarter = FindObjectOfType<GameStarter>();

        
    }

    public void PlayerJoined(PlayerRef player)
    {
        gameStarter.InitializeNetworkRunner(Runner);

        Debug.Log("PlayerJoined");

        Debug.Log(Runner.SessionInfo.PlayerCount);

        if (player == Runner.LocalPlayer)
        {
            Runner.Spawn(playerPrefab, new Vector3(0, 1, 0), Quaternion.identity, player);
        }

        if (Runner.SessionInfo.PlayerCount == 1)
        {
            gameStarter.SpawnRoad();
        }

        if (Runner.SessionInfo.PlayerCount == Runner.SessionInfo.MaxPlayers)
        {
            StartCoroutine(gameStarter.StartCountdown());
        }

    }
}
