using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{

    private FinishElements _finishElements;

    [SerializeField]
    private MovingForwardPlayer movingForwardPlayer;

    private void Start()
    {
       _finishElements = FindObjectOfType<FinishElements>();
    }

    public void FinshGame()
    {

        movingForwardPlayer.ChangeBoostMultiply(0);
        movingForwardPlayer.ChangeCurrentSpeedMultiply(0);

        _finishElements.SetActivityUI(true);

        

    }

}
