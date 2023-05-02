using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAvatarChanger : MonoBehaviour
{

    private Sprite _icon;

    private Image _changeIcon;

    private int _iconNumber;

    private FirebaseDatabaseController _firebase;

    public void Initialize(Sprite icon, Image changeIcon, FirebaseDatabaseController firebase, int iconNumber)
    {
        this._icon = icon;
        this._changeIcon = changeIcon;
        this._firebase = firebase;
        this._iconNumber = iconNumber;
    }

    public void ChangeIcon()
    {
        _changeIcon.sprite = _icon;

        _firebase.ChangeCurrentUser(_firebase.UserDataTransfer.id, _firebase.UserDataTransfer.nickName, _firebase.UserDataTransfer.goldCoins, _iconNumber, _firebase.UserDataTransfer.bestTime, _firebase.UserDataTransfer.car);
    }

}
