using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombspawn : MonoBehaviour
{

    public GameObject bomb;
    //public GameObject bombs;

    Vector2 WhereToSpawn;
    public float fireRate = 0.1f;
    private float nextFire = 0.0f;
    //public bool land;


    void Start()

    {
    }
    // {
    //    Destroy (bomb, 1f);
    // }

    // Update is called once per frame
    void Update()
    {




    }
    // {
    //  if (Time.time < nextFire)
    //     nextFire = Time.time + fireRate;
    //  GameObject clone = Instantiate(bomb, transform.position, transform.rotation) as GameObject;
    //}



} 


