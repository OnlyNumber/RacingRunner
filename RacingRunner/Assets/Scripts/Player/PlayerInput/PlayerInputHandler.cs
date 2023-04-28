using UnityEngine;
using Fusion;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerInputHandler : MonoBehaviour
{
    private int linePos = 0;

    private bool isMobile;

    [SerializeField]
    private float checkZone;

    [SerializeField]
    LineController myPlayer;

    [SerializeField]
    private IPlatform platformControl;

    private NetworkBool isPressedBrake = false;

    private BrakeButton brakeButton;

    private void Start()
    {
        brakeButton = FindObjectOfType<BrakeButton>();

        brakeButton.onPointerDown += PressButton;

        isMobile = Application.isMobilePlatform;

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
    }

    void PressButton()
    {
        isPressedBrake = !isPressedBrake;
        //Debug.Log(isPressedBrake);
    }

    private void ChooseDirection(IPlatform.Directions direction)
    {
        switch (direction)
        {
            case (IPlatform.Directions.right):
                {
                    Debug.Log("Right");
                    /*linePos = 1;*/myPlayer.MoveToLine(1);
                    break;
                }

            case (IPlatform.Directions.left):
                {
                    Debug.Log("Left");
                    /*linePos = -1;*/ myPlayer.MoveToLine(-1);
                    break;
                }
        }
    }

     


    public NetworkInputData GetNetworkInput()
    {
        NetworkInputData networkInputData = new NetworkInputData();

        networkInputData.line = linePos;

        networkInputData.isPressedBrake = isPressedBrake;

        //isPressedBrake = false;

        linePos = 0;
        
        return networkInputData;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("SomeTrigger");
    }


}
