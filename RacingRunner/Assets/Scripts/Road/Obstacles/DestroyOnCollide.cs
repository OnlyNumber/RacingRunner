using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class DestroyOnCollide : NetworkBehaviour
{
    private const int PlayerLayer = 7;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == PlayerLayer)
        {
            gameObject.SetActive(false);
        }
    }

    

    
}
