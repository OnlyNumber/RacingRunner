using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class Finish : NetworkBehaviour
{
    private int place;

    private FinishElements _finishElements;

    private FirebaseDatabaseController _firebase;

    [SerializeField]
    private int prize;


    private void Start()
    {
       _finishElements = FindObjectOfType<FinishElements>();

       _firebase = FindObjectOfType<FirebaseDatabaseController>();
    }

    public void FinshGame()
    {



        //movingForwardPlayer.ChangeBoostMultiply(0);
        //movingForwardPlayer.ChangeCurrentSpeedMultiply(0);

        _finishElements.SetActivityUI(true);

        _finishElements.Txt_Prize.text = prize.ToString();

        _finishElements.Txt_SumPrize.text = _firebase.userDataTransfer.goldCoins.ToString() + prize;


        _finishElements.Txt_FinishTime.text = " ";

        _finishElements.Txt_FinishPlace.text = $"{place}";


        _firebase.ChangeCurrentUser(_firebase.userDataTransfer.id, _firebase.userDataTransfer.nickName, _firebase.userDataTransfer.goldCoins + prize, _firebase.userDataTransfer.avatarIcon, _firebase.userDataTransfer.bestTime, _firebase.userDataTransfer.car);




    }

}
