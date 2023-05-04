using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class Finish : NetworkBehaviour
{
    private int place = 1;

    private FinishElements _finishElements;

    private FirebaseDatabaseController _firebase;

    [SerializeField]
    private int prize;

    private void Start()
    {
       _finishElements = FindObjectOfType<FinishElements>();

       _firebase = FindObjectOfType<FirebaseDatabaseController>();
    }

    public void FinshGame(float timer)
    {
        float time = _firebase.UserDataTransfer.bestTime;

        _finishElements.SetActivityUI(true);

        _finishElements.Txt_Prize.text = $"{prize.ToString()}";
        _finishElements.Txt_SumPrize.text = $"{_firebase.UserDataTransfer.goldCoins.ToString()} + { prize}";

        if (timer % 60 > 10)
        {
            _finishElements.Txt_FinishTime.text = $" {(int)(timer / 60)} : {(int)(timer % 60)}";
        }
        else
        {
            _finishElements.Txt_FinishTime.text = $" {(int)(timer / 60)} : 0{(int)(timer % 60)}";
        }

        _finishElements.Txt_FinishPlace.text = $"Your place: {place}";

        if(time < 0)
        {
            time = timer;
        }
        else if(_firebase.UserDataTransfer.bestTime > timer)
        {
            time = timer;
        }

        _firebase.ChangeCurrentUser(_firebase.UserDataTransfer.id, _firebase.UserDataTransfer.nickName, _firebase.UserDataTransfer.goldCoins + prize, _firebase.UserDataTransfer.avatarIcon, time, _firebase.UserDataTransfer.car);

        Rpc_ChangePlace(place + 1);

    }

    [Rpc]
    private void Rpc_ChangePlace(int place)
    {
        this.place = place;
    }


}
