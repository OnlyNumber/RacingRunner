using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;


public class ColliderChecker : NetworkBehaviour
{
    private const int OBSTACLE_LAYER = 6;

    private const int FINISH_LAYER = 10;

    private const int USEFUL_ITEM_LAYER = 9;

    [SerializeField]
    private MovingForwardPlayer movingForward;

    /*private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.layer)
        {
            case OBSTACLE_LAYER:
                {
                    StartCoroutine(collision.gameObject.GetComponent<IObstacleEffect>().ObstacleEffect(movingForward));
                    break;
                }
            case USEFUL_ITEM_LAYER:
                {
                    StartCoroutine(collision.gameObject.GetComponent<IObstacleEffect>().ObstacleEffect(movingForward));
                    break;
                }

            case FINISH_LAYER:
                {

                    movingForward.ChangeBoostMultiply(0);
                    movingForward.ChangeCurrentSpeedMultiply(0);

                    GetComponent<BoxCollider>().enabled = false;

                    if(HasInputAuthority)
                        collision.gameObject.GetComponent<Finish>().FinshGame(GetComponent<InterfaceController>()._timeTicker);

                    //finish.FinshGame();
                    //StartCoroutine(other.gameObject.GetComponent<IObstacleEffect>().ObstacleEffect(movingForward));
                    break;
                }
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if(HasStateAuthority)
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
        }
    }



}
