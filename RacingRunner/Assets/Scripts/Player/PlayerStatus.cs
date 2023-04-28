using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class PlayerStatus : NetworkBehaviour
{

    [SerializeField]
    private MovingForward movingForward;

    [SerializeField]
    private float debuffTime;

    [SerializeField]
    private float buffTime;

    [SerializeField]
    private float changeModificator;

    /*public IEnumerator BoostEffect()
    {
        movingForward.ChangeSpeedIncreaceToNormal();

        movingForward.ChangeSpeedIncreace(changeModificator);

        yield return new WaitForSecondsRealtime(buffTime);

        movingForward.ChangeSpeedIncreaceToNormal();
    }

    public IEnumerator SlowdownEffect()
    {
        movingForward.ChangeSpeedIncreaceToNormal();

        movingForward.ChangeSpeedIncreace(changeModificator);

        yield return new WaitForSeconds(debuffTime);

        movingForward.ChangeSpeedIncreaceToNormal();

    }

    public void AccidentEffect()
    {

    }*/

}
