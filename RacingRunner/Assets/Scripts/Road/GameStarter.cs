using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using System;

public class GameStarter : NetworkBehaviour
{
    [SerializeField]
    private GameObject _startPanel;

    [SerializeField]
    private float _distanceToNextFragment;

    [SerializeField]
    private NetworkObject _finishFragment;

    [SerializeField]
    private FragmentRoad _roadFragment;

    [SerializeField]
    private int _roadLegth;

    private List<FragmentRoad> road = new List<FragmentRoad>();


    public void SpawnRoad()
    {
        Debug.Log("Spawn road");

        for (int i = 1; i < _roadLegth; i++)
        {
            if (Runner == null)
            {
                Debug.Log("Runner == null");
            }

            road.Add(Runner.Spawn(_roadFragment, new Vector3(0, 0, _distanceToNextFragment * i)));
        }

        Runner.Spawn(_finishFragment, new Vector3(0, 0, _distanceToNextFragment * _roadLegth)).transform.SetParent(gameObject.transform);

    }


    public IEnumerator StartCountdown()
    {
        yield return new WaitForSeconds(5);

        StartGame();
    }

    [ContextMenu("StartGame")]
    public void StartGame()
    {
        Runner.SessionInfo.IsOpen = false;
        Runner.SessionInfo.IsVisible = false;

        foreach (var item in road)
        {
            item.SpawnWave();
        }

        List<MovingForwardPlayer> movingPlayers = new List<MovingForwardPlayer>();

        foreach (var item in FindObjectsOfType<MovingForwardPlayer>())
        {
            movingPlayers.Add(item);
        }


        foreach (var localPlayer in movingPlayers)
        {
            localPlayer.ChangeBoostToNormalStart();
            localPlayer.GetComponent<InterfaceController>().Rpc_Init();
        }

    }

}
