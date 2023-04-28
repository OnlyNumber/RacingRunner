using UnityEngine;
using TMPro;

public class MainMenuUIHandler : MonoBehaviour
{
    



    /*public GameObject playerDetailsPanel;
    public GameObject sessionBrowserPanel;
    public GameObject createSessionPanel;
    public GameObject statusPanel;

    public TMP_InputField playerNameInputField;

    public TMP_InputField sessionNameInputField;*/

    private const string GAME_PLAY_SCENE = "GamePlay";

    private void Start()
    {
        
    }

    private void HideAllPanels()
    {
        /*playerDetailsPanel.SetActive(false);
        sessionBrowserPanel.SetActive(false);
        createSessionPanel.SetActive(false);
        statusPanel.SetActive(false);*/
    }

    public void OnJoinGameClick()
    {
        NetworkRunnerHandler networkRunnerHandler = FindObjectOfType<NetworkRunnerHandler>();

        networkRunnerHandler.OnJoinLobby();

        HideAllPanels();

        
        //sessionBrowserPanel.SetActive(true);

        FindObjectOfType<SessionListUIHandler>(true).OnLookingForGameSession();
    }

    public void OnStartNewSessionClicked()
    {

        NetworkRunnerHandler networkRunnerHandler = FindObjectOfType<NetworkRunnerHandler>();

        networkRunnerHandler.CreateGame(Random.Range(-30000000000f, 30000000000f).ToString(), GAME_PLAY_SCENE);

        HideAllPanels();
    }




    public void GoBackToMainMenu()
    {

        HideAllPanels();

        //playerDetailsPanel.SetActive(true);
    }


    public void OnCreateNewSessionMenu()
    {
        HideAllPanels();

        //createSessionPanel.SetActive(true);
    }

    public void OnJoiningServer()
    {

        HideAllPanels();

        //statusPanel.SetActive(true);
    }

    


}
