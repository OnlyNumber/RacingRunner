using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class RoadSpawner : NetworkBehaviour
{
    [SerializeField]
    private float distanceToNextFragment;

    [SerializeField]
    private NetworkObject roadFragment;

    [SerializeField]
    private int roadLegth;

    private void Start()
    {
        //StartCoroutine(StartSpawn());
    }

    [ContextMenu("SpawnRoad")]
    private void SpawnRoad()
    {
        for (int i = 0; i < roadLegth; i++)
        {
            Debug.Log(i);

            Runner.Spawn(roadFragment, new Vector3(0, 0, distanceToNextFragment * i));

        }
    }
    


}
