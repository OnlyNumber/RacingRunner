using UnityEngine;
using Fusion;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class SessionFinder : MonoBehaviour
{
    public SessionInfo firstSession;

    NetworkRunnerHandler networkRunnerHandler;

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
            Scene = SceneUtility.GetBuildIndexByScenePath($"scenes/{"GamePlay"}"),
            GameMode = GameMode.AutoHostOrClient, // or GameMode.Shared
        });

        if (result.Ok)
        {
            // all good
        }
        else
        {
            Debug.LogError($"Failed to Start: {result.ShutdownReason}");
        }
    }

    public void JoingGame()
    {
        //NetworkRunnerHandler networkRunnerHandler = FindObjectOfType<NetworkRunnerHandler>();
        networkRunnerHandler.OnJoinLobby();



        if (firstSession != null)
        {
            AddedSessionInfoListUIItem_OnJoinSession(firstSession);
        }
        else
        {
            //networkRunnerHandler.OnJoinLobby();

            Debug.Log("firstSession == null");
        }
    }


    private void AddedSessionInfoListUIItem_OnJoinSession(SessionInfo sessionInfo)
    {
        NetworkRunnerHandler networkRunnerHandler = FindObjectOfType<NetworkRunnerHandler>();

        networkRunnerHandler.JoinGame(sessionInfo);

        MainMenuUIHandler mainMenuUIHandler = FindObjectOfType<MainMenuUIHandler>();
        mainMenuUIHandler.OnJoiningServer();

    }

}
