using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    //public GameObject mine;
    public GameObject enemies;
    //public GameObject slide_obstacle;
    public GameObject Luftwaffe; 
    float randY;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;
    int num;
    //int num1;

    
    //public Enemy enemy;
    public GameObject player;

    void Start()
    {
        //enemy = GameObject.FindGameObjectWithTag("enemy");
        //mine = GameObject.FindGameObjectWithTag("mine");
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randY = Random.Range(-0.0f, 0.0f);
            Random_pos();
            if (num == 0)
            {
                whereToSpawn = new Vector2(player.transform.position.x + 5, transform.position.y);
                Instantiate(enemy,  whereToSpawn, Quaternion.identity);
            }

            if(num == 0)
            {
                whereToSpawn = new Vector2(player.transform.position.x + 5, transform.position.y);
                Instantiate(Luftwaffe, whereToSpawn, Quaternion.identity);
            }
        }
       
            if (enemies.transform.position.y <= -100)
            {
                Destroy(GameObject.Find("Enemy(Clone)"), 5);
            }
        
 
    }
    void Random_pos()
    {
        num = (Random.Range(0, 3));
        Debug.Log(num);
    }
    //void Random_pos1()
    //{
    //    num1 = (Random.Range(0, 2));
    //    Debug.Log(num1);
    //}
}
