using UnityEngine;
using Fusion;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class SessionFinder : MonoBehaviour
{
    public SessionInfo firstSession;

    NetworkRunnerHandler networkRunnerHandler;

    private const string GAME_PLAY_SCENE = "GamePlay";

    private void Start()
    {
        
    }

    public void StartFinding()
    {
        networkRunnerHandler = FindObjectOfType<NetworkRunnerHandler>();

        //networkRunnerHandler.OnJoinLobby();
    }

    public void StartSearch()
    {
        var ads = StartPlayer(FindObjectOfType<NetworkRunner>());
    }

    public async Task StartPlayer(NetworkRunner runner)
    {

        var result = await runner.StartGame(new StartGameArgs()
        {
            PlayerCount = 2,
            Scene = SceneUtility.GetBuildIndexByScenePath($"scenes/{GAME_PLAY_SCENE}"),
            GameMode = GameMode.AutoHostOrClient, 
        });

        if (!result.Ok)
        {
            Debug.LogError($"Failed to Start: {result.ShutdownReason}");
        }
        
    }

}
