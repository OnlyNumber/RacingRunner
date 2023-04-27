using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class MovingForward : NetworkBehaviour 
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float startSpeed;

    [SerializeField]
    private float speedIncreacer;

    [SerializeField]
    private float speedDecreacer;

    [SerializeField]
    private float maxSpeed;

    private bool isBrake;

    //[SerializeField]


    public override void FixedUpdateNetwork()
    {
        

        if (GetInput(out NetworkInputData networkInputData))
        {
            isBrake = networkInputData.isPressedBrake;

        }
            SpeedChanger();
        
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void SpeedChanger()
    {
        if (isBrake)
        {
            Debug.Log("Brake");

            if (speed - speedDecreacer * Time.deltaTime > 0)
            {
                speed -= speedDecreacer * Time.deltaTime;
            }
            else
            {
                speed = 0;
            }

        }
        else
        {
            if (speed > 0)
            {
                speed += speedIncreacer * Time.deltaTime * (maxSpeed / speed);
            }
            else
            {
                speed = startSpeed;
            }
        }

        if (transform.position.z > 250)
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }

     


}
