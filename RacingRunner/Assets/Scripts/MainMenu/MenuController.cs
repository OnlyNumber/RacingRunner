using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private const string LOG_IN_MENU_SCENE = "LogInMenu";

    [SerializeField]
    private GameObject _mainUI;

    [SerializeField]
    private GameObject _garageUI;

    [SerializeField]
    private GameObject _raitingUI;

    [SerializeField]
    private GameObject _optionsUI;

    [SerializeField]
    private GameObject _avatarIconsUI;

    public void GoToMainUI()
    {
        HeadeAllPanels();
        _mainUI.SetActive(true);
    }

    public void GoToGarageUI()
    {
        HeadeAllPanels();
        _garageUI.SetActive(true);
       
    }

    public void GoToOptionsUI()
    {
        HeadeAllPanels();
        _optionsUI.SetActive(true);

    }

    public void GoToRaitingUI()
    {
        HeadeAllPanels();
        _raitingUI.SetActive(true);

    }

    public void GoToAvatarIconsUI()
    {
        HeadeAllPanels();
        _avatarIconsUI.SetActive(true);
    }

    public void SignOut()
    {
        LogInScript.SignOut();

        SceneManager.LoadScene(LOG_IN_MENU_SCENE);

    }

    public void ExitFromGame()
    {
        Application.Quit();
    }

    public void HeadeAllPanels()
    {
        _mainUI.SetActive(false);
        _garageUI.SetActive(false);
        _raitingUI.SetActive(false);
        _optionsUI.SetActive(false);
        _avatarIconsUI.SetActive(false);
    }


}
