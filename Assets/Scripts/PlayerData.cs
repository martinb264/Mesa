using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
   
    public float[] playerPosition;
    
    public float[] respawnPosition;

    public PlayerData(Transform player)
    {
        Debug.Log("Transform x " + player.position.x);
        playerPosition = new float[2];
        respawnPosition = new float[2];

        playerPosition[0] = player.position.x;
        playerPosition[1] = player.position.y;

        respawnPosition[0] = LevelManagerScript.instance.getRespawnPosition().position.x;
        respawnPosition[1] = LevelManagerScript.instance.getRespawnPosition().position.y;
    }
}
