using UnityEngine;
using Fusion;

public class NetworkPlayerController : NetworkBehaviour
{
    //[SerializeField]
    //float speed;

    //[SerializeField]
    //Rigidbody2D rigidbody;


    private void Start()
    {
    }

    public override void FixedUpdateNetwork()
    {
        Move();

        RotateWeapon();
    }

    private void Move()
    {
        if (GetInput(out NetworkInputData networkInput))
        {
            //rigidbody.MovePosition(transform.position + (Vector3)networkInput.movementAxisInput * speed);
        }
    }

    private void RotateWeapon()
    {
        if (GetInput(out NetworkInputData networkInput))
        {
            if (networkInput.mousePosition == null)
            {
                Debug.Log("No position");
            }

            
        }
    }



}
