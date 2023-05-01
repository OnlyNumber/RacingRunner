using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class NitroObstacle : NetworkBehaviour, IObstacleEffect
{
    [SerializeField]
    private float changeModificator;

    [SerializeField]
    private float timer;

    public IEnumerator ObstacleEffect(MovingForwardPlayer movingForward)
    {
        Debug.Log("NitroObstacleEffect");

        movingForward.ChangeBoostToNormal();

        movingForward.ChangeBoostMultiply(changeModificator);

        //movingForward.ChangeCurrentSpeed(0.7f);

        yield return new WaitForSecondsRealtime(timer);

        //Debug.Log("ObstacleEffect2");

        movingForward.ChangeBoostToNormal();
    }

}
