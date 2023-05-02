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
        _coinsText.text = _firebase.userDataTransfer.goldCoins.ToString();
    }


}
