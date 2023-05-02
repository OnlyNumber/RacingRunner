using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _coinsText;

    [SerializeField]
    private FirebaseDatabaseController _firebase;

    private void Start()
    {
        _firebase.onDataLoadedPlayer += InitializeCoins;
    }

    private void InitializeCoins()
    {
        Debug.Log("Coins" + _firebase.UserDataTransfer.goldCoins);

        _coinsText.text = _firebase.UserDataTransfer.goldCoins.ToString();
    }


}
