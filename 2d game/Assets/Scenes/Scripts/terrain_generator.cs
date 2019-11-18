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
    public GameObject detection;
    public GameObject player;

    public player_move _player_move;
    //public Score scoreValue;

    Vector2 whereToSpawn;
    int num;

    // Start is called before the first frame update
    void Start()
    {
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
        if (_player_move.switched)
        {
            if (Score.scoreValue > 0 && Score.scoreValue <= 50)
            {
                Random_pos();
                if (num == 0)
                {
                    whereToSpawn = new Vector2(player.transform.position.x - 9, Ground_big_easy.transform.position.y);
                    Instantiate(Ground_big_easy, whereToSpawn, Quaternion.identity);
                }
                if (num == 1)
                {
                    whereToSpawn = new Vector2(player.transform.position.x - 9, Ground_big2_easy.transform.position.y);
                    Instantiate(Ground_big2_easy, whereToSpawn, Quaternion.identity);
                }
                if (num == 2)
                {

                    whereToSpawn = new Vector2(player.transform.position.x - 3, Ground_small_easy.transform.position.y);
                    Instantiate(Ground_small_easy, whereToSpawn, Quaternion.identity);
                }
            }
            if (Score.scoreValue > 50 && Score.scoreValue <= 70)
            {
                Random_pos();
                if (num == 0)
                {
                    whereToSpawn = new Vector2(player.transform.position.x - 9, Ground_big_medium.transform.position.y);
                    Instantiate(Ground_big_medium, whereToSpawn, Quaternion.identity);
                }
                if (num == 1)
                {
                    whereToSpawn = new Vector2(player.transform.position.x - 9, Ground_big2_medium.transform.position.y);
                    Instantiate(Ground_big2_medium, whereToSpawn, Quaternion.identity);
                }
                if (num == 2)
                {

                    whereToSpawn = new Vector2(player.transform.position.x - 3, Ground_small_medium.transform.position.y);
                    Instantiate(Ground_small_medium, whereToSpawn, Quaternion.identity);
                }
            }

            Debug.Log("new platform");
            _player_move.switched = false;
        }





    }

    void Random_pos()
    {
        num = (Random.Range(0, 3));
        Debug.Log(num);
    }
}
