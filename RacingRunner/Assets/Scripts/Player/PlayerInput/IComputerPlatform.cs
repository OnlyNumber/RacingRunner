using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IComputerPlatform : IPlatform
{
    Vector2 tapPosition;
    private Vector2 secondTap;

    private bool isSwiping;

    private float checkZone;

    public IComputerPlatform(float checkZone)
    {
        this.checkZone = checkZone;
    }

    public IPlatform.Directions Controlling()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isSwiping = true;
            tapPosition = Input.mousePosition;

        }
        else if (Input.GetMouseButtonUp(0))
        {
            ResetSwipe();
        }

        return CheckPos();
    }

    private IPlatform.Directions CheckPos()
    {
        IPlatform.Directions direction = (IPlatform.Directions)(-1);

        secondTap = Vector2.zero;

        if (isSwiping)
        {

            if (Input.GetMouseButton(0))
            {
                secondTap = (Vector2)Input.mousePosition - tapPosition;
            }
        }

        if (secondTap.magnitude > checkZone)
        {

            if (Mathf.Abs(secondTap.x) > Mathf.Abs(secondTap.y))
            {
                if (secondTap.x > 0)
                {
                    direction = (IPlatform.Directions)0; 
                }
                else
                {
                    direction = (IPlatform.Directions)1;   
                }
            }
            
            ResetSwipe();

        }

        return direction;


    }

    private void ResetSwipe()
    {
        isSwiping = false;

        tapPosition = Vector2.zero;
        secondTap = Vector2.zero;
    }




}
