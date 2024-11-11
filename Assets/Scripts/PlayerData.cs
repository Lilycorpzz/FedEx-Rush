using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int deliveryAmount;
    public float[] truckPosition;

    public PlayerData( DistanceTrackers player)
    {
        truckPosition = new float[3];
        truckPosition[0] = player.transform.position.x;
        truckPosition[1] = player.transform.position.y;
        truckPosition[2] = player.transform.position.z;
    }
}
