using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilObstacle : MonoBehaviour, IObstacleEffect
{

    [SerializeField]
    private float changeModificator;

    [SerializeField]
    public float timer;

    public IEnumerator ObstacleEffect(MovingForward movingForward)
    {
        Debug.Log("ObstacleEffect");

        movingForward.ChangeBoostToNormal();

        movingForward.StopBoost();
        
        movingForward.ChangeCurrentSpeed(0.7f);

        yield return new WaitForSecondsRealtime(timer);

        Debug.Log("ObstacleEffect2");

        movingForward.ChangeBoostToNormal();
    }


   

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger" + IObstacleEffect.PLAYER_LAYER + "Player layer" + other.gameObject.layer);

        if (other.gameObject.layer == IObstacleEffect.PLAYER_LAYER)
        {
            StartCoroutine(ObstacleEffect(other.GetComponent<MovingForward>()));
        }

    }

}
