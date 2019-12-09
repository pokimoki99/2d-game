using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class terrain_generator : MonoBehaviour
{

    public GameObject Ground_big_easy;
    public GameObject Ground_big2_easy;
    public GameObject Ground_small_easy;
    public GameObject Ground_big_medium;
    public GameObject Ground_big2_medium;
    public GameObject Ground_small_medium;
    public GameObject hp_power_up;
    public GameObject detection;
    public GameObject player;

    public Detecc detecc;
    public power_up _tank;
    //public Score scoreValue;

    public bool easy, medium, hard;
    Vector2 whereToSpawn;
    int num;
    int hp;
    int tank;

    // Start is called before the first frame update
    void Start()
    {
        easy = false;
        medium = false;
        hard = false;
        if (Score.scoreValue == 0)
        {
            whereToSpawn = new Vector3(0.4f, -5.32f, 16.54f);
            Instantiate(Ground_big_easy, whereToSpawn, Quaternion.identity);
        }
        if (Score.scoreValue >= 50)
        {
            whereToSpawn = new Vector3(0.4f, -5.32f, 16.54f);
            Instantiate(Ground_big_medium, whereToSpawn, Quaternion.identity);
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (detecc.switched)
        {
            Random_pos();
            if (Score.scoreValue > 0 && Score.scoreValue <= 50)
            {
                easy = true;
                
                if (num == 0)
                {
                    whereToSpawn = new Vector2(player.transform.position.x + 9, Ground_big_easy.transform.position.y-3.5f);
                    Instantiate(Ground_big_easy, whereToSpawn, Quaternion.identity);
                    detecc.switched = false;
                    Debug.Log("spawned0");

                }
                else if (num == 1)
                {
                    whereToSpawn = new Vector2(player.transform.position.x + 9, Ground_big2_easy.transform.position.y- 3.5f);
                    Instantiate(Ground_big2_easy, whereToSpawn, Quaternion.identity);
                    detecc.switched = false;
                    Debug.Log("spawned1");
                }
                else if (num == 2)
                {
                    whereToSpawn = new Vector2(player.transform.position.x + 3, Ground_small_easy.transform.position.y- 3.5f);
                    Instantiate(Ground_small_easy, whereToSpawn, Quaternion.identity);
                    detecc.switched = false;
                    Debug.Log("spawned2");
                }
                if (hp==0)
                {
                    whereToSpawn = new Vector2(player.transform.position.x + 14, hp_power_up.transform.position.y);
                    Instantiate(hp_power_up, whereToSpawn, Quaternion.identity);
                }
                if (tank == 0)
                {
                    whereToSpawn = new Vector2(player.transform.position.x + 14, _tank.tank_power_up.transform.position.y);
                    Instantiate(_tank.tank_power_up, whereToSpawn, Quaternion.identity);
                }


            }
            if (Score.scoreValue > 50 && Score.scoreValue <= 70)
            {
                medium = true;
                Random_pos();
                if (num == 0)
                {
                    whereToSpawn = new Vector2(player.transform.position.x - 9, Ground_big_medium.transform.position.y- 3.5f);
                    Instantiate(Ground_big_medium, whereToSpawn, Quaternion.identity);
                }
                if (num == 1)
                {
                    whereToSpawn = new Vector2(player.transform.position.x - 9, Ground_big2_medium.transform.position.y- 3.5f);
                    Instantiate(Ground_big2_medium, whereToSpawn, Quaternion.identity);
                }
                if (num == 2)
                {
                    whereToSpawn = new Vector2(player.transform.position.x - 14, Ground_small_medium.transform.position.y- 3.3f);
                    Instantiate(Ground_small_medium, whereToSpawn, Quaternion.identity);
                }
            }

            Debug.Log("new platform");
            detecc.switched = false;
        }





    }

    void Random_pos()
    {
        num = (Random.Range(0, 3));
        hp = (Random.Range(0, 2));
        tank = (Random.Range(0, 10));
        Debug.Log(num);
    }
}
