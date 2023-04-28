using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObstacleEffect 
{
    public const int PLAYER_LAYER = 7;

    public const int UNTOUCHABLE_LAYER = 8;


    public IEnumerator ObstacleEffect(MovingForwardPlayer movingForward);

    

}
