using UnityEngine;
using Fusion;

public class MobileInput : IInput
{
    Vector3 weapnJoystick;
    Vector3 moveJoysticl;
    
    public void Start()
    {

        moveJoysticl = Vector3.zero; //GameObject.Find("MovingJoystick").GetComponent<FixedJoystick>(); 

        weapnJoystick = Vector3.zero;//GameObject.Find("WeaponJoystick").GetComponent<FixedJoystick>();

    }

    public void GetInput(out Vector2 moveInputVector, out Vector2 mousePosition, out NetworkBool isCanShoot)
    {
        moveInputVector.x = moveJoysticl.x;
        moveInputVector.y = moveJoysticl.y;
        mousePosition.x = weapnJoystick.x;
        mousePosition.y = weapnJoystick.y;
        isCanShoot = true;

        if (mousePosition == Vector2.zero)
        {
            isCanShoot = false;
        }


    }
}
