using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using System;

public class GameStarter : NetworkBehaviour
{

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

        //while (true)
        //{

            for (int i = 1; i < _roadLegth; i++)
            {
                if (Runner == null)
                {
                    Debug.Log("Runner == null");
                }

                //Runner.Spawn(_roadFragment, new Vector3(0, 0, _distanceToNextFragment * i));

                //road.Add();
                road.Add(Runner.Spawn(_roadFragment, new Vector3(0, 0, _distanceToNextFragment * i)));
            }


            Runner.Spawn(_finishFragment, new Vector3(0, 0, _distanceToNextFragment * _roadLegth)).transform.SetParent(gameObject.transform);


        //}
    }

    /*IEnumerator st()
    {
        yield return new WaitUntil(Runner != null);
    }*/

    [ContextMenu("StartGame")]
    public void StartGame()
    {
        foreach (var item in road)
        {
            item.SpawnWave();
        }

        if (Runner == null)
        {
            Debug.Log("Runner == null");
        }

        foreach (var item in FindObjectsOfType<MovingForwardPlayer>())
        {
            Debug.Log(item.GetComponent<NetworkObject>().Id);

            item.GetComponent<MovingForwardPlayer>().ChangeBoostToNormalStart();
        }

    }

}
