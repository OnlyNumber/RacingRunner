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
        /*if(movingForward.GetComponent<ColliderChecker>().isOiled)
        {
            Debug.Log("movingForward.GetComponent<ColliderChecker>().test != null)");
            yield return new WaitForSecondsRealtime(0);
        }
        else
        {
            movingForward.GetComponent<ColliderChecker>().isOiled = true;
        }*/

        Runner.Despawn(GetComponent<NetworkObject>());

        Debug.Log("OilObstacleEffect");

        movingForward.ChangeBoostToNormal();

        movingForward.StopBoost();
        
        movingForward.ChangeCurrentSpeedMultiply(0.7f);

        yield return new WaitForSecondsRealtime(10);

        //Debug.Log("ObstacleEffect2");

        movingForward.ChangeBoostToNormal();
        gameObject.SetActive(true);
        //movingForward.GetComponent<ColliderChecker>().isOiled = false;

    }
}
