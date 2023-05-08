using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class OnJoin : SpawnerPlayer
{
    private GameStarter gameStarter;
    private Dictionary<int, NetworkPlayer> mapTokenIdWithNetworkPlayer;

    private void Start()
    {
        mapTokenIdWithNetworkPlayer = new Dictionary<int, NetworkPlayer>();

        //_sessionFinder = FindObjectOfType<SessionFinder>(true);

        gameStarter = FindObjectOfType<GameStarter>();

    }

    public override void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        if (runner.IsServer)
        {
            int playerToken = GetPlayerToken(runner, player);

            Debug.Log("OnPlayerJoined We are server Spawn player");

            if (mapTokenIdWithNetworkPlayer.TryGetValue(playerToken, out NetworkPlayer networkPlayer))
            {
                Debug.Log($"Found old connection token for {playerToken}, Assigning controls to start player");

                networkPlayer.GetComponent<NetworkObject>().AssignInputAuthority(player);
            }
            else
            {
                Debug.Log($"Spawning new player for connection token {playerToken}");

                NetworkPlayer spawnedNetworkPlayer = runner.Spawn(playerPrefab, Vector3.zero, Quaternion.identity, player);

                spawnedNetworkPlayer.token = playerToken;

                _spawnedCharacters.Add(player, spawnedNetworkPlayer);

                if (runner.SessionInfo.PlayerCount == 1)
                {
                    gameStarter = FindObjectOfType<GameStarter>();
                    gameStarter.SpawnRoad();
                }

                if (runner.SessionInfo.PlayerCount == 2)
                {
                    StartCoroutine(gameStarter.StartCountdown());
                }

            }
        }

    }

    int GetPlayerToken(NetworkRunner runner, PlayerRef player)
    {
        if (runner.LocalPlayer == player)
        {
            return ConnectionTokenUtils.HashToken(GameManager.instance.GetConnectionToken());
        }
        else
        {
            var token = runner.GetPlayerConnectionToken();

            if (token != null)
            {
                return ConnectionTokenUtils.HashToken(token);
            }

            Debug.LogError($"GetPlayerToken returned invalid token");

            return 0;
        }
    }

}
