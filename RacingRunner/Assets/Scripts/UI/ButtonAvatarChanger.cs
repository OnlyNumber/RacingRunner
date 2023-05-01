using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAvatarChanger : MonoBehaviour
{

    private Sprite _icon;

    private Image _changeIcon;

    private int _iconNumber;

    private FirebaseDatabaseControllerMenu _firebase;

    public void Initialize(Sprite icon, Image changeIcon, FirebaseDatabaseControllerMenu firebase, int iconNumber)
    {
        this._icon = icon;
        this._changeIcon = changeIcon;
        this._firebase = firebase;
        this._iconNumber = iconNumber;
    }

    public void ChangeIcon()
    {
        _changeIcon.sprite = _icon;

        _firebase.ChangeCurrentUser(_firebase.userDataTransfer.id, _firebase.userDataTransfer.nickName, _firebase.userDataTransfer.goldCoins, _iconNumber, _firebase.userDataTransfer.bestTime, _firebase.userDataTransfer.car);

        _firebase.SaveData(_firebase.userDataTransfer.id, _firebase.userDataTransfer.nickName, _firebase.userDataTransfer.goldCoins, _firebase.userDataTransfer.avatarIcon, _firebase.userDataTransfer.bestTime, _firebase.userDataTransfer.car);

    }

}
