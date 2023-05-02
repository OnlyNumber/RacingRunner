using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class MovingForwardObstacle : NetworkBehaviour
{
    [SerializeField]
    private float speed;

    public override void FixedUpdateNetwork()
    {
        if(Time.deltaTime < 0.1)
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }

}
