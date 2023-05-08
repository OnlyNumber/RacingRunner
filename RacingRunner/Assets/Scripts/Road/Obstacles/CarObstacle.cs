using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class CarObstacle : NetworkBehaviour, IObstacleEffect
{
    [SerializeField]
    private float timer;

    [SerializeField]
    private float teleportDistance;

    public IEnumerator ObstacleEffect(MovingForwardPlayer movingForward)
    {
        Runner.Despawn(GetComponent<NetworkObject>());

        movingForward.gameObject.layer = IObstacleEffect.UNTOUCHABLE_LAYER;

        if (transform.position.z - teleportDistance > 0)
        {
            movingForward.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - teleportDistance);
        }
        else
        {
            movingForward.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }

        movingForward.ChangeCurrentSpeedMultiply(0);

        yield return new WaitForSecondsRealtime(timer);

        movingForward.gameObject.layer = IObstacleEffect.PLAYER_LAYER;


    }

    private void OnDestroy()
    {
        Debug.Log("OnDestroy CarObstacle");
    }
    public void StopEffect()
    {
        StopAllCoroutines();
    }

}
