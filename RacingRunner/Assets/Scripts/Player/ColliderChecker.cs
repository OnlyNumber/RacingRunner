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
            case FINISH_LAYER:
                {
                    if (nitroEffect != null)
                    {
                        StopCoroutine(nitroEffect);
                    }
                    if(oilEffects != null)
                    {
                        StopCoroutine(oilEffects);
                    }


                    movingForward.ChangeBoostMultiply(0);
                    movingForward.ChangeCurrentSpeedMultiply(0);

                    GetComponent<BoxCollider>().enabled = false;

                    if (HasInputAuthority)
                    {
                        collision.gameObject.GetComponent<Finish>().FinshGame(GetComponent<InterfaceController>().TimeTicker);
                        GetComponent<InterfaceController>().Finish();
                    }


                    break;
                }
        }
    }
    Coroutine nitroEffect;
    Coroutine oilEffects;
    IObstacleEffect stateList;
    private void OnTriggerEnter(Collider other)
    {
        

        if(HasStateAuthority)
        switch (other.gameObject.layer)
        {
            case OBSTACLE_LAYER:
                {
                        if (oilEffects != null)
                        {
                            StopCoroutine(oilEffects);
                        }



                        oilEffects = StartCoroutine(other.gameObject.GetComponent<IObstacleEffect>().ObstacleEffect(movingForward));
                        
                    break;
                }
            case USEFUL_ITEM_LAYER:
                {
                        
                        if(nitroEffect != null)
                        {
                            StopCoroutine(nitroEffect);
                        }

                        nitroEffect = StartCoroutine(other.gameObject.GetComponent<IObstacleEffect>().ObstacleEffect(movingForward));
                        break;
                }
        }
    }



}
