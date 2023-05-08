using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class MovingForwardPlayer : NetworkBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _startSpeed;

    [SerializeField]
    private float _currentBoost;

    [SerializeField]
    private float _normalSpeedIncreacer;

    [SerializeField]
    private float _speedDecreacer;

    [SerializeField]
    private float _maxSpeed;

    private bool isBrake;

    [SerializeField]
    private NetworkRigidbody _networkRigidbody;

    private void Start()
    {
        
    }

    public override void FixedUpdateNetwork()
    {
        if (GetInput(out NetworkInputData networkInputData))
        {
            isBrake = networkInputData.isPressedBrake;
        }

        //Debug.Log("Speed " + _speed);

        //Debug.Log("Boost " + _currentBoost);

        SpeedChanger();
        //transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        //_networkRigidbody.Rigidbody.MovePosition(transform.position + Vector3.forward * Time.deltaTime);

        _networkRigidbody.TeleportToPosition(transform.position + Vector3.forward * _speed * Runner.DeltaTime);

        //Debug.Log(Vector3.forward);

        //Debug.Log(Vector3.forward * _speed * Time.deltaTime);
    }

    private void SpeedChanger()
    {
        if (isBrake)
        {
            if (_speed - _speedDecreacer * Time.deltaTime > 0)
            {
                _speed -= _speedDecreacer * Time.deltaTime;
            }
            else
            {
                _speed = 0;
            }

        }
        else
        {
            if (_speed < _maxSpeed)
            {
                //if (_currentBoost * Runner.DeltaTime < 1)
                //{
                    //Debug.Log("_speed += _currentBoost * Runner.DeltaTime");
                    _speed += _currentBoost * Runner.DeltaTime; //* (maxSpeed / speed);
                //}
            }

            
        }

    }

    public void ChangeBoostMultiply(float changeSpeed)
    {
        Rpc_RequestSpeedBoost(_currentBoost * changeSpeed);
    }

    public void StopBoost()
    {
        Rpc_RequestSpeedBoost(0);
    }


    public void ChangeBoostToNormal()
    {
        //Debug.Log("ChangeSpeedIncreaceToNormal");

        Rpc_RequestSpeedBoost(_normalSpeedIncreacer);
    }

    public void ChangeCurrentSpeedMultiply(float speedEffect)
    {
        //Debug.Log(speed + " * " + speedEffect + " = " + speed * speedEffect);

        Rpc_RequestSpeed(_speed * speedEffect);
    }

    public void ChangeBoostToNormalStart()
    {
        Debug.Log("ChangeSpeedIncreaceToNormal");

        Rpc_RequestSpeedBoostStart(_normalSpeedIncreacer);
    }

    [Rpc(RpcSources.All, RpcTargets.All)]
    private void Rpc_RequestSpeedBoostStart(float changeSpeedIncreace)
    {
        //Debug.Log("Rpc_RequestSpeedBoostStart");

        _currentBoost = changeSpeedIncreace;
    }



    [Rpc(RpcSources.StateAuthority, RpcTargets.All)]
    private void Rpc_RequestSpeed(float changeSpeed)
    {
        Debug.Log("Rpc_RequestSpeed");
        _speed = changeSpeed;
    }

    [Rpc(RpcSources.StateAuthority, RpcTargets.All)]
    private void Rpc_RequestSpeedBoost(float changeSpeedIncreace)
    {
        Debug.Log("Rpc_RequestSpeedBoost");
        _currentBoost = changeSpeedIncreace;

    }

}
