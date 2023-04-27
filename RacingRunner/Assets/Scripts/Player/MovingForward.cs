using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class MovingForward : NetworkBehaviour 
{
    [SerializeField]
    private float speed;

    public override void FixedUpdateNetwork()
    {
        if(transform.position.z > 250 )
        {
            transform.position = new Vector3(0,0,0);
        }

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

}
