using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    Object BulletRef;
    public bool fire = false;

    // Start is called before the first frame update
    void Start()
    {
        BulletRef = Resources.Load("Bullet");
    }

    // Update is called once per frame
    void Update()
    {
        if (fire==true)
        {
            bulletfire();
        }
        //bulletfire();
        //if(Input.GetButtonDown("Fire1"))
        //{
        //    GameObject bullet = (GameObject)Instantiate(BulletRef);
        //    bullet.transform.position = new Vector3(transform.position.x + .4f, transform.position.y + .2f, -1f);
        //}
    }

    public void bulletfire()
    {
        GameObject bullet = (GameObject)Instantiate(BulletRef);
        bullet.transform.position = new Vector3(transform.position.x + .4f, transform.position.y + .2f, -1f);
        fire = false;
    }
}
