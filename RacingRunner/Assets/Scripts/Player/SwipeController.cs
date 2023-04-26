using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    //private PlayerController myPlayer;

    private Vector2 tapPosition;
    private Vector2 secondTap;

    private bool isMobile;
    private bool isSwiping;

    [SerializeField]
    private float checkZone;

    LineController myPlayer;

    public enum Directions
    {
        right = 0,
        left = 1,
    }

    private IPlatform platformControl;

    private void Start()
    {
        isMobile = Application.isMobilePlatform;
        myPlayer = GetComponent<LineController>();

        if (!isMobile)
        {

            platformControl = new IComputerPlatform(checkZone);

        }
        else
        {

            platformControl = new IMobilePlatform(checkZone);
        }

    }

    private void Update()
    {

        ChooseDirection(platformControl.Controlling());

        /*if (SpawnManager.instance.ISGAME)
        {
            ChooseDirection(platformControl.Controlling());
        }*/
    }

    private void ChooseDirection(Directions direction)
    {
        switch (direction)
        {
            case (Directions.right):
                {
                    //Debug.Log("Right");
                    myPlayer.MoveToLine(1);
                    break;
                }

            case (Directions.left):
                {
                    Debug.Log("Left");
                    myPlayer.MoveToLine(-1);
                    break;
                }
        }



    }
    




}
