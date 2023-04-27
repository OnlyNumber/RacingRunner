using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMobilePlatform : IPlatform
{
    Vector2 tapPosition;
    private Vector2 secondTap;

    private bool isSwiping;

    private float checkZone;

    public IMobilePlatform(float checkZone)
    {
        this.checkZone = checkZone;
    }


    public IPlatform.Directions Controlling()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                isSwiping = true;
                tapPosition = Input.GetTouch(0).position;

            }
            else if (Input.GetTouch(0).phase == TouchPhase.Canceled ||
                Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                ResetSwipe();
            }
        }

        return CheckPos();
    }

    private IPlatform.Directions CheckPos()
    {
        IPlatform.Directions direction = (IPlatform.Directions)(-1);

        secondTap = Vector2.zero;

        if (isSwiping)
        {

            if (Input.touchCount > 0)
            {
                secondTap = Input.GetTouch(0).position - tapPosition;
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