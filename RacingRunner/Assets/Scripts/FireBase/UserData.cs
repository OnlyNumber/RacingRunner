using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData
{
    public string id;
    public string nickName;
    public int goldCoins;
    public int avatarIcon;
    public float bestTime;
    public int car;
    public UserData( string id, string nickName, int goldCoins, int avatarIcon, float bestTime,int car)
    {
        this.id = id;
        this.nickName = nickName;
        this.goldCoins = goldCoins;
        this.avatarIcon = avatarIcon;
        this.bestTime = bestTime;
        this.car = car;
    }



}
