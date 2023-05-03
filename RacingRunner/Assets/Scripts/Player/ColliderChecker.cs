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

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.layer)
        {
            /*case OBSTACLE_LAYER:
                {
                    StartCoroutine(collision.gameObject.GetComponent<IObstacleEffect>().ObstacleEffect(movingForward));
                    break;
                }
            case USEFUL_ITEM_LAYER:
                {
                    StartCoroutine(collision.gameObject.GetComponent<IObstacleEffect>().ObstacleEffect(movingForward));
                    break;
                }*/

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
    }
    Coroutine nowEf;
    IObstacleEffect stateList;
    private void OnTriggerEnter(Collider other)
    {
        

        if(HasStateAuthority)
        switch (other.gameObject.layer)
        {
            case OBSTACLE_LAYER:
                {

                        if (stateList != null)
                        {
                            stateList.StopEffect();
                        }

                        stateList = other.gameObject.GetComponent<IObstacleEffect>();

                        //Debug.Log()

                        /* stateList.Add(other.gameObject.GetComponent<NetworkBehaviour>());

                         //stateList[2].StopAllCoroutines

                         foreach (var item in stateList)
                         {
                             item.StopAllCoroutines();
                         }*/




                        StartCoroutine(other.gameObject.GetComponent<IObstacleEffect>().ObstacleEffect(movingForward));
                        
                    break;
                }
            case USEFUL_ITEM_LAYER:
                {
                        //stateList.Add(other.gameObject.GetComponent<NetworkBehaviour>());
                        if(stateList != null)
                        {
                            stateList.StopEffect();
                        }
                        if(nowEf != null)
                        {
                            StopCoroutine(nowEf);
                        }



                        stateList = other.gameObject.GetComponent<IObstacleEffect>();
                        /*foreach (var item in stateList)
                        {
                            item.StopAllCoroutines();
                        }*/

                        //GetComponent<MovingForwardPlayer>().StopAllCoroutines();

                        nowEf = StartCoroutine(other.gameObject.GetComponent<IObstacleEffect>().ObstacleEffect(movingForward));
                        break;
                }
        }
    }



}
