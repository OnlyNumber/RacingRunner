using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using UnityEngine.SceneManagement;

public class GoToLoadMenu : NetworkBehaviour
{
    private const string NEXT_SCENE = "GamePlay";

    public void GoToLoad()
    {
        FindObjectOfType<NetworkRunner>().Shutdown();
        SceneManager.LoadScene(NEXT_SCENE);
    }
}
