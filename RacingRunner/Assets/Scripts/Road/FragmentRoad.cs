using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class FragmentRoad : NetworkBehaviour
{
    [SerializeField]
    private SpawnPoints[] spawnWaves;

    [SerializeField]
    private NetworkObject[] _obstacles;



    private void Start()
    {
        foreach (var item in spawnWaves)
        {
            try
            {
                SpawnWave(item);
            }
            catch
            {

            }
        }
    }

    public void SpawnWave(SpawnPoints spawnWave)
    {
        int randomNumber;

        for (int i = 0; i < spawnWave.spawnPoints.Length; i++)
        {
            randomNumber = Random.Range(0, _obstacles.Length);

            if (randomNumber != 0)
            {
                Runner.Spawn(_obstacles[Random.Range(0, _obstacles.Length)], spawnWave.spawnPoints[i].position, spawnWave.spawnPoints[i].rotation);
            }
        }
    }

}
