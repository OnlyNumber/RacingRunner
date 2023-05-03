using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using UnityEngine.SceneManagement;

public class GoToLoadMenu : NetworkBehaviour
{
    private const string LOAD_SCENE = "LoadScene";

    public void GoToLoad()
    {
        Runner.Shutdown();
        SceneManager.LoadScene(LOAD_SCENE);
    }
}
