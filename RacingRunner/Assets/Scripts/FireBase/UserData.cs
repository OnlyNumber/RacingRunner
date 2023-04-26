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

    public UserData( string id, string nickName, int goldCoins, int avatarIcon, float bestTime)
    {
        this.id = id;
        this.nickName = nickName;
        this.goldCoins = goldCoins;
        this.avatarIcon = avatarIcon;
        this.bestTime = bestTime;
    }



}
