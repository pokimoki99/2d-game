using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int health;
    public int score;
    public float[] position;

    public PlayerData (player_move player, Health hp, Score point)
    {
        position = new float[2];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;

        health = hp.health;
        score = point.savedata;
    }
}
