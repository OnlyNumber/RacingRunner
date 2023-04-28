using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class OilObstacle : NetworkBehaviour, IObstacleEffect
{
    [SerializeField]
    public float timer;

    public IEnumerator ObstacleEffect(MovingForwardPlayer movingForward)
    {
        Debug.Log("ObstacleEffect");

        movingForward.ChangeBoostToNormal();

        movingForward.StopBoost();
        
        movingForward.ChangeCurrentSpeedMultiply(0.7f);

        yield return new WaitForSecondsRealtime(timer);

        Debug.Log("ObstacleEffect2");

        movingForward.ChangeBoostToNormal();
    }
}
