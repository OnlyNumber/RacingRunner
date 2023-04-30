using UnityEngine;
using Fusion;

public class FragmentRoad : NetworkBehaviour
{
    [SerializeField]
    private SpawnPoints[] spawnWaves;

    [SerializeField]
    private NetworkObject[] _obstacles;




    public void SpawnWave()
    {
        int randomNumber;

        foreach (var spawnWave in spawnWaves)
        {
            for (int i = 0; i < spawnWave.spawnPoints.Length; i++)
            {
                randomNumber = Random.Range(0, _obstacles.Length);

                if (randomNumber != 0)
                {
                    Runner.Spawn(_obstacles[randomNumber], spawnWave.spawnPoints[i].position, spawnWave.spawnPoints[i].rotation).transform.SetParent(transform);
                }
            }
        }

    }

}
