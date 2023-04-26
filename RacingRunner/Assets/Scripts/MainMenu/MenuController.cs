using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private const string LOG_IN_MENU_SCENE = "LogInMenu";

    [SerializeField]
    private GameObject MainUI;

    [SerializeField]
    private GameObject GarageUI;

    public void GoToMainUI()
    {
        MainUI.SetActive(true);
        GarageUI.SetActive(false);
    }

    public void GoToGarageUI()
    {
        GarageUI.SetActive(true);
        MainUI.SetActive(false);
    }

    public void SignOut()
    {
        LogInScript.SignOut();

        SceneManager.LoadScene(LOG_IN_MENU_SCENE);

    }
}
