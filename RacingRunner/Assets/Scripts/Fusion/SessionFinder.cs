using UnityEngine;
using Fusion;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class SessionFinder : MonoBehaviour
{
    public SessionInfo firstSession;

    private const string GAME_PLAY_SCENE = "GamePlay";

    Task ads;

   /* private void Start()
    {
        StartSearch();
    }*/

    private void Update()
    {
        if (ads == null)
        StartSearch();
    }


    public void StartSearch()
    {
        ads = StartPlayer(FindObjectOfType<NetworkRunner>());
    }


    public async Task StartPlayer(NetworkRunner runner)
    {

        var result = await runner.StartGame(new StartGameArgs()
        {
            
            PlayerCount = 2,
            //Scene = SceneUtility.GetBuildIndexByScenePath($"scenes/{GAME_PLAY_SCENE}"),
            GameMode = GameMode.Shared, 
        });



        if (!result.Ok)
        {
            Debug.LogError($"Failed to Start: {result.ShutdownReason}");
        }
        
    }

}
