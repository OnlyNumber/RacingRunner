using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class OilObstacle : NetworkBehaviour, IObstacleEffect
{
    [SerializeField]
    public float Timer;

    [SerializeField]
    private Collider _collider;

    

    public IEnumerator ObstacleEffect(MovingForwardPlayer movingForward)
    {
        

        movingForward.ChangeBoostToNormal();

        movingForward.StopBoost();
        
        movingForward.ChangeCurrentSpeedMultiply(0.7f);

        StartCoroutine(HideOil());

        yield return new WaitForSecondsRealtime(Timer);

        //Debug.Log("ObstacleEffect2");

        movingForward.ChangeBoostToNormal();
        
        gameObject.SetActive(true);
        //movingForward.GetComponent<ColliderChecker>().isOiled = false;

    }

    private IEnumerator HideOil()
    {
        _collider.enabled = false;
        yield return new WaitForSecondsRealtime(2);

        _collider.enabled = true;

    }

    public void StopEffect()
    {
        StopAllCoroutines();
    }
}
