using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemyspeed = 5f;
   // public GameObject Enemy;
    //public GameObject detecc;
  //  Vector3 spawn;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * enemyspeed * Time.deltaTime);
    
    }
}
