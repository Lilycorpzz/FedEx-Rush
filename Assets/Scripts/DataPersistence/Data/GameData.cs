using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int truckDistance;

    // the values defined in this contructor will be the default values
    // the game starts when theres no data to load
    public GameData()
    {
        this.truckDistance = 0;
    }
}
