using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class DestroyOnTouch : NetworkBehaviour
{
    private const int START_LAYER = 11;
    private const int FINISH_LAYER = 10;
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == FINISH_LAYER || other.gameObject.layer == START_LAYER) 
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == FINISH_LAYER || collision.gameObject.layer == START_LAYER)
        {
            gameObject.SetActive(false);
        }
    }

}
