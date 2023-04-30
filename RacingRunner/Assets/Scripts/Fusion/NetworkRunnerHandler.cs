using UnityEngine;
using System;
using Fusion;
using Fusion.Sockets;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class NetworkRunnerHandler : MonoBehaviour
{
    private int maxPlayers = 2;

    public NetworkRunner networkRunnerPrefab;

    private NetworkRunner networkRunner;

    private const string MENU_SCENE = "MenuScene";

    private void Awake()
    {
        NetworkRunner networkRunnerScene = FindObjectOfType<NetworkRunner>();

        if(networkRunnerScene != null)
        {
            networkRunner = networkRunnerScene;
        }
    }

    private void Start()
    {

        if (networkRunner == null)
        {
            networkRunner = Instantiate(networkRunnerPrefab);

            networkRunner.name = "Network runner";

            if (SceneManager.GetActiveScene().name != MENU_SCENE)
            {
                var clientTask = InitializeNetworkRunner(networkRunner, GameMode.AutoHostOrClient, "TestSessionName", GameManager.instance.GetConnectionToken(), NetAddress.Any(), SceneManager.GetActiveScene().buildIndex, null);
            }

            Debug.Log("Server NetworkRunner started");
        }
    }

    protected virtual Task InitializeNetworkRunner(NetworkRunner runner, GameMode gameMode, string sessionName, byte[] connectionToken, NetAddress addres, SceneRef scene, Action<NetworkRunner> initialized)
    {

        Debug.Log("InitializeNetworkRunner  TestSessionName");
        
        var sceneManager = runner.GetComponents(typeof(MonoBehaviour)).OfType<INetworkSceneManager>().FirstOrDefault();

        if(sceneManager == null)
        {
            sceneManager = runner.gameObject.AddComponent<NetworkSceneManagerDefault>();
        }

        return runner.StartGame(new StartGameArgs
        {
            PlayerCount = maxPlayers,
            GameMode = gameMode,
            Address = addres,
            Scene = scene,
            SessionName = sessionName,
            CustomLobbyName = "OurLobbyID",
            Initialized = initialized,
            SceneManager = sceneManager,
            ConnectionToken = connectionToken
        });
    }

    public void CreateGame(string sessionName, string sceneName)
    {
        Debug.Log($"Create session {sessionName} scene {sceneName} build Index {SceneUtility.GetBuildIndexByScenePath($"scenes/{sceneName}")}");

        var clientTask = InitializeNetworkRunner(networkRunner, GameMode.Host, sessionName, GameManager.instance.GetConnectionToken(), NetAddress.Any(), SceneUtility.GetBuildIndexByScenePath($"scenes/{sceneName}"), null);
    }




   


}
