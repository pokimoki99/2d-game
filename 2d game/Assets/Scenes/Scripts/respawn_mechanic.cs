using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn_mechanic : MonoBehaviour
{
    public GameObject detecc;//but also attack
    public GameObject player;
    Vector3 spawn;

    public terrain_generator _terrain_generator;
    public player_move _player_move;

    public Health _Health;

    public event EventHandler OnHealthLoss;
    public event EventHandler OnHealthGain;

    // Start is called before the first frame update
    void Start()
    {
        detecc = GameObject.FindGameObjectWithTag("Respawn");
        player = GameObject.FindGameObjectWithTag("player");
        spawn = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent("Health.cs");
        if (player.transform.position.y < -6)
        {
            destroyTerrain();
            player.transform.position = spawn;
            _Health.health -= 1;
            CallHealthLoss();

        }
        if (_player_move.damage == true)
        {
            Destroy(GameObject.Find("Enemy(Clone)"));
            _Health.health -= 1;
            CallHealthLoss();
            _player_move.damage = false;
        }
        if (_player_move.heal == true)
        {
            _Health.health += 1;
            CallHealthGain();
            _player_move.damage = false;
        }

    }

    void CallHealthLoss()
    {
        OnHealthLoss?.Invoke(this, EventArgs.Empty);
    }
    void CallHealthGain()
    {
        OnHealthGain?.Invoke(this, EventArgs.Empty);
    }
    void destroyTerrain()
    {
        Destroy(GameObject.Find("Ground_big(Clone)"));
        Destroy(GameObject.Find("Ground_big2(Clone)"));
        Destroy(GameObject.Find("Ground_small(Clone)"));
        Destroy(GameObject.Find("Enemy(Clone)"));
        Destroy(GameObject.Find("slide_obstacles(Clone)"));
    }
}
