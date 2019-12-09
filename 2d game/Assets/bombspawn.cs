using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombspawn : MonoBehaviour
{

    public GameObject bomb;
    public GameObject plane;

    Vector2 WhereToSpawn;

    bool fire = true;


    void Start()

    {
    }
    // {
    //    Destroy (bomb, 1f);
    // }

    // Update is called once per frame
    void Update()
    {

        if (plane.transform.position.y <= 0.6f)
        {
            Debug.Log("coords");
            if (!fire)
            {
                WhereToSpawn = new Vector2(plane.transform.position.x, plane.transform.position.y);
                Instantiate(bomb, WhereToSpawn, Quaternion.identity);
                fire = false;
            }
        }



    }
    // {
    //  if (Time.time < nextFire)
    //     nextFire = Time.time + fireRate;
    //  GameObject clone = Instantiate(bomb, transform.position, transform.rotation) as GameObject;
    //}



} 


