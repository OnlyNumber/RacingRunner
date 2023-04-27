using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

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


    public void JoingGame()
    {
        //NetworkRunnerHandler networkRunnerHandler = FindObjectOfType<NetworkRunnerHandler>();
        

        if (firstSession != null)
        {
            AddedSessionInfoListUIItem_OnJoinSession(firstSession);
        }
        else
        {
            //networkRunnerHandler.OnJoinLobby();

            networkRunnerHandler.OnJoinLobby();

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
