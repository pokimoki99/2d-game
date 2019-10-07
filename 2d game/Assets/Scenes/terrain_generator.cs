using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrain_generator : MonoBehaviour
{

    public GameObject Ground_big;
    public GameObject Ground_big2;
    public GameObject Ground_small;
    public GameObject foothold;
    public GameObject detection;
    public GameObject player;

    public player_move _player_move;

    Vector2 whereToSpawn;
    int num;

    // Start is called before the first frame update
    void Start()
    {
      
    }
    // Update is called once per frame
    void Update()
    {
        if (_player_move.switched)
        {
            Random_pos();
            if (num == 0)
            {
                whereToSpawn = new Vector2(player.transform.position.x + 9, Ground_big.transform.position.y);
                Instantiate(Ground_big, whereToSpawn, Quaternion.identity);
            }
            if (num == 1)
            {
                whereToSpawn = new Vector2(player.transform.position.x + 9, Ground_big2.transform.position.y);
                Instantiate(Ground_big2, whereToSpawn, Quaternion.identity);
            }
            if (num == 2)
            {

                whereToSpawn = new Vector2(player.transform.position.x + 3, Ground_small.transform.position.y);
                Instantiate(Ground_small, whereToSpawn, Quaternion.identity);
            }
            if (num==3)
            {
                whereToSpawn = new Vector2(player.transform.position.x + 3, foothold.transform.position.y);
                Instantiate(foothold, whereToSpawn, Quaternion.identity);
            }
            Debug.Log(Ground_big.transform.position.x);
            _player_move.switched = false;
        }

       
        

      
    }

    void Random_pos()
    {
        num = (Random.Range(0, 3));
        Debug.Log(num);
    }
}
