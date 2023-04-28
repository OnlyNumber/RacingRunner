using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class MovingForwardPlayer : NetworkBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float startSpeed;

    [SerializeField]
    private float currentBoost;

    [SerializeField]
    private float normalSpeedIncreacer;

    [SerializeField]
    private float speedDecreacer;

    [SerializeField]
    private float maxSpeed;

    private bool isBrake;

    private void Start()
    {
        currentBoost = normalSpeedIncreacer;
    }

    public override void FixedUpdateNetwork()
    {
        if (GetInput(out NetworkInputData networkInputData))
        {
            isBrake = networkInputData.isPressedBrake;

        }

        MoveForward();

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void MoveForward()
    {
        if (isBrake)
        {
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
            //Debug.Log("speed" + speedIncreacer);
            if (speed < maxSpeed)
            {
                if(currentBoost * Time.deltaTime < 1)
                speed += currentBoost * Time.deltaTime; //* (maxSpeed / speed);

                Debug.Log(currentBoost * Time.deltaTime);
            
            }
            
        }

    }

    public void ChangeBoostMultiply(float changeSpeed)
    {
        Rpc_RequestSpeedBoost(currentBoost * changeSpeed);
    }

    public void StopBoost()
    {
        Rpc_RequestSpeedBoost(0);
    }


    public void ChangeBoostToNormal()
    {
        Debug.Log("ChangeSpeedIncreaceToNormal");

        Rpc_RequestSpeedBoost(normalSpeedIncreacer);
    }

    public void ChangeCurrentSpeedMultiply(float speedEffect)
    {
        Debug.Log(speed + " * " + speedEffect + " = " + speed * speedEffect);

        Rpc_RequestSpeed(speed * speedEffect);
    }




    [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority)]
    private void Rpc_RequestSpeed(float changeSpeed)
    {

        speed = changeSpeed;

    }

    [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority)]
    private void Rpc_RequestSpeedBoost(float changeSpeedIncreace)
    {

        currentBoost = changeSpeedIncreace;

    }

}
