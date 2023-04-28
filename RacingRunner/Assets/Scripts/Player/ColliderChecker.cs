using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderChecker : MonoBehaviour
{
    private const int OBSTACLE_LAYER = 6;

    private const int FINISH_LAYER = 10;

    private const int USEFUL_ITEM_LAYER = 9;


    [SerializeField]
    private MovingForwardPlayer movingForward;

    [SerializeField]
    private Finish finish;

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.layer)
        {
            case OBSTACLE_LAYER:
                {
                    StartCoroutine(other.gameObject.GetComponent<IObstacleEffect>().ObstacleEffect(movingForward));
                    break;
                }
            case USEFUL_ITEM_LAYER:
                {
                    StartCoroutine(other.gameObject.GetComponent<IObstacleEffect>().ObstacleEffect(movingForward));
                    break;
                }

            case FINISH_LAYER:
                {
                    finish.FinshGame();
                    //StartCoroutine(other.gameObject.GetComponent<IObstacleEffect>().ObstacleEffect(movingForward));
                    break;
                }
        }

    }


}
