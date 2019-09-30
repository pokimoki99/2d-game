using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn_mechanic : MonoBehaviour
{
    public GameObject detecc;//but also attack
    public GameObject player;
    Vector3 spawn;

    public Health playerHealthScript;

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
        if (player.transform.position.y < detecc.transform.position.y)
        {
            
            player.transform.position = spawn;
            playerHealthScript.health -= 1;
        }
    }
}
