using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Fusion;
using UnityEngine.SceneManagement;

public class InterfaceController : NetworkBehaviour
{
    private PlayerIndicators _playerIndicators;

    public float TimeTicker { private set; get; }

    public Transform AntoherPlayer;

    //private Material _playerMaterial;

    //private Renderer _playerShader;

    [Networked(OnChanged = nameof(OnChangeMethode))]
    private NetworkBool _isStart { get; set; }

    private bool _isFinish;

    public void Start()
    {
        _playerIndicators = FindObjectOfType<PlayerIndicators>();

    }

    private void Update()
    {
        if (_isStart && HasInputAuthority && !_isFinish)
        {
            _playerIndicators.Distance.text = $"{(int)transform.position.z}";

            UpdateTimer();

            if (AntoherPlayer != null && AntoherPlayer.position.z < transform.position.z)
            {
                _playerIndicators.Place.text = "1/2";
            }
            else
            {
                _playerIndicators.Place.text = "2/2";
            }
        }
    }

    public void Finish()
    {
        _isFinish = !_isFinish;
    }

    private void UpdateTimer()
    {
        TimeTicker += Time.deltaTime;

        if (TimeTicker % 60 > 10)
        {
            _playerIndicators.Time.text = $" {(int)(TimeTicker / 60)} : {(int)(TimeTicker % 60)}";
        }
        else
        {
            _playerIndicators.Time.text = $" {(int)(TimeTicker / 60)} : 0{(int)(TimeTicker % 60)}";
        }
    }

    [ContextMenu("Find_AnotherPlayer")]
    public void Find_AnotherPlayer()
    {
        _playerIndicators.WaitingPanel.SetActive(false);

        foreach (var anotherPlayer in FindObjectsOfType<MovingForwardPlayer>())
        {
            Debug.Log(anotherPlayer.gameObject.name);

            if (anotherPlayer != GetComponent<MovingForwardPlayer>())
            {
                Debug.Log(anotherPlayer.gameObject.name);

                this.AntoherPlayer = anotherPlayer.transform;
            }
        }
    }

    [Rpc(RpcSources.StateAuthority, RpcTargets.InputAuthority)]
    public void Rpc_Init()
    {
        _isStart = true;
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
