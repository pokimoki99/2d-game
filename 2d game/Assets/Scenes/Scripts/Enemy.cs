using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemyspeed = 5f;
    public GameObject enemy;
    //public GameObject detecc;
  //  Vector3 spawn;




    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("enemy");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * enemyspeed * Time.deltaTime);
        if (enemy.transform.position.y <= -100)
        {
            Destroy(GameObject.FindWithTag("enemy"));
        }

    }
    void OnCollionEnter(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Bullet"))
        {
            Destroy(GameObject.FindWithTag("enemy"));
            Destroy(col.gameObject);
            
        }
        
    }

}
