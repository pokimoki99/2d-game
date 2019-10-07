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
            
            player.transform.position = spawn;
            _Health.health -= 1;
            Destroy(_terrain_generator.tera);
        }
        if (_player_move.damage==true)
        {
            _Health.health -= 1;
            _player_move.damage = false;
        }

    }
}
