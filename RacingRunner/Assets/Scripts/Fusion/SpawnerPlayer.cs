using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Fusion.Sockets;
using System;
using UnityEngine.SceneManagement;

public class SpawnerPlayer : MonoBehaviour, INetworkRunnerCallbacks
{
    public NetworkPlayer playerPrefab;

    //private Dictionary<int, NetworkPlayer> mapTokenIdWithNetworkPlayer;

    private PlayerInputHandler characterInputHandler;

    private GameStarter gameStarter;

    public Dictionary<PlayerRef, NetworkPlayer> _spawnedCharacters = new Dictionary<PlayerRef, NetworkPlayer>();

    private const string MENU_SCENE = "MenuScene";

    private const string GAME_PLAY = "GamePlay";

    //private SessionFinder _sessionFinder;

    public Dictionary<PlayerRef, NetworkPlayer> GetSpawnedPlayers()
    {
        Dictionary<PlayerRef, NetworkPlayer> spawnedCharactersCopy = new Dictionary<PlayerRef, NetworkPlayer>();

        foreach(var item in _spawnedCharacters)
        {
            spawnedCharactersCopy.Add(item.Key, item.Value);
        }

        return spawnedCharactersCopy;
    }

    private void Start()
    {
        //mapTokenIdWithNetworkPlayer = new Dictionary<int, NetworkPlayer>();
        
        //_sessionFinder = FindObjectOfType<SessionFinder>(true);

        gameStarter = FindObjectOfType<GameStarter>();

    }

    int GetPlayerToken(NetworkRunner runner, PlayerRef player)
    {
        if(runner.LocalPlayer == player)
        {
            return ConnectionTokenUtils.HashToken(GameManager.instance.GetConnectionToken());
        }
        else
        {
            var token = runner.GetPlayerConnectionToken();

            if(token != null)
            {
                return ConnectionTokenUtils.HashToken(token);
            }

            Debug.LogError($"GetPlayerToken returned invalid token");

                return 0;
        }
    }

    public void OnInput(NetworkRunner runner, NetworkInput input)
    {
        if (characterInputHandler == null && NetworkPlayer.local)
        {
            characterInputHandler = NetworkPlayer.local.GetComponent<PlayerInputHandler>();
        }

        if(characterInputHandler != null)
        {
            input.Set(characterInputHandler.GetNetworkInput());
        }


    }

    public virtual void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        if(runner.IsServer)
        {

            Debug.Log("OnPlayerJoined We are server Spawn player");


                NetworkPlayer spawnedNetworkPlayer = runner.Spawn(playerPrefab, Vector3.zero, Quaternion.identity, player);


                _spawnedCharacters.Add(player, spawnedNetworkPlayer);

                Debug.Log(_spawnedCharacters.Count);

                if(runner.SessionInfo.PlayerCount == 1)
                {
                    gameStarter = FindObjectOfType<GameStarter>();
                    gameStarter.SpawnRoad();
                }

                

                if(runner.SessionInfo.PlayerCount == runner.SessionInfo.MaxPlayers)
                {
                    //Debug.Log("gameStarter.StartCountdown()");
                    StartCoroutine(gameStarter.StartCountdown());
                }
                
        }



        
    }

    public void OnConnectedToServer(NetworkRunner runner)
    {
        Debug.Log("OnConnectedToServer");
    }

    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {
        Debug.Log("OnConnectFailed");
    }

    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {
        Debug.Log("OnConnectRequest");
    }

    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {

    }

    public void OnDisconnectedFromServer(NetworkRunner runner)
    {

        Debug.LogError("Disconneted");
        Debug.Log("OnDisconnectedFromServer");
    }

    public async void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {
        Debug.Log("Host migration");

        await runner.Shutdown();

    }

    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {
    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {

        if (_spawnedCharacters.TryGetValue(player, out NetworkPlayer networkObject))
        {
            _spawnedCharacters.Remove(player);

            if(networkObject != null)
            runner.Despawn(networkObject.GetComponent<NetworkObject>());
        }

    }

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data)
    {
    }

    public void OnSceneLoadDone(NetworkRunner runner)
    {
    }

    public void OnSceneLoadStart(NetworkRunner runner)
    {
    }

    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {
        Debug.Log("OnSessionListUpdated");
    }

    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
        Debug.Log(shutdownReason.ToString());

        SceneManager.LoadScene(MENU_SCENE);

        Debug.Log("OnShutdown");
    }

    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {

    }
}
