using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class TestSessionSecret : NetworkBehaviour
{
    [ContextMenu("SecretTask")]
    public void SecretTask()
    {
        Runner.SessionInfo.IsOpen = false;
        Runner.SessionInfo.IsVisible = false;
    }

    [ContextMenu("SecretTaskOff")]
    public void SecretTaskOff()
    {
        Runner.SessionInfo.IsOpen = true;
        Runner.SessionInfo.IsVisible = true;
    }

}
