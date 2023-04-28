using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObstacleEffect 
{
    public const int PLAYER_LAYER = 7;

    public IEnumerator ObstacleEffect(MovingForward movingForward);

    

}
