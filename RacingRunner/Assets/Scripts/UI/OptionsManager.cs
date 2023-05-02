using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fusion;

public class OptionsManager : NetworkBehaviour
{
    [SerializeField]
    private GameObject _optionsPanel;

    private const string MENU_SCENE = "MenuScene";

    public void SetActiveOptions(bool activity)
    {
        _optionsPanel.SetActive(activity);
    }

    public void LeaveGame()
    {
        Runner.Shutdown();
        SceneManager.LoadScene(MENU_SCENE);
    }


}
