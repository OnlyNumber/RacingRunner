using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Fusion;

public class InterfaceController : NetworkBehaviour
{
    private TMP_Text dist;

    private TMP_Text _place;

    private TMP_Text _timerText;

    private float _timeTicker;

    public Transform antoherPlayer;

    [Networked(OnChanged = nameof(OnChangeMethode))]
    private NetworkBool isStart { get; set; }


    public void Start()
    {
        _place = GameObject.Find("PlaceInRaceText").GetComponent<TMP_Text>();
        dist = GameObject.Find("DistanceToStartText").GetComponent<TMP_Text>();
        _timerText = GameObject.Find("TimerText").GetComponent<TMP_Text>();
    }

    private void Update()
    {
        if (HasInputAuthority && antoherPlayer != null)
        {
            dist.text = $"{transform.position.z}";

            UpdateTimer();

            if (antoherPlayer.position.z < transform.position.z)
            {
                _place.text = "1/2";
            }
            else
            {
                _place.text = "1/2";
            }
        }
    }

    private void UpdateTimer()
    {
        _timeTicker += Time.deltaTime;

        if (_timeTicker % 60 > 10)
        {
            _timerText.text = $" {(int)(_timeTicker / 60)} : {(int)(_timeTicker % 60)}";
        }
        else
        {
            _timerText.text = $" {(int)(_timeTicker / 60)} : 0{(int)(_timeTicker % 60)}";
        }

    }

    [ContextMenu("Find_AnotherPlayer")]
    public void Find_AnotherPlayer()
    {
        foreach (var anotherPlayer in FindObjectsOfType<MovingForwardPlayer>())
        {
            Debug.Log(anotherPlayer.gameObject.name);

            if (anotherPlayer != GetComponent<MovingForwardPlayer>())
            {
                Debug.Log(anotherPlayer.gameObject.name);

                this.antoherPlayer = anotherPlayer.transform;
            }
        }
    }

    [Rpc(RpcSources.StateAuthority, RpcTargets.InputAuthority)]
    public void Rpc_Init()
    {
        isStart = true;
    }


    private static void OnChangeMethode(Changed<InterfaceController> changed)
    {
        changed.Behaviour.OnChangeMethode();
    }

    private void OnChangeMethode()
    {
        Debug.Log("OnChangeMethode");
        Find_AnotherPlayer();
    }

}
