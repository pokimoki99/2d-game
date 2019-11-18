using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shooting : MonoBehaviour
{
    Object bulletRef;
    // Start is called before the first frame update
    void Start()
    {
        bulletRef = Resources.Load("Bullet");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = (GameObject)Instantiate(bulletRef);
            bullet.transform.position = new Vector3(transform.position.x + .4f, transform.position.y + .2f, -1);
        }
    }
}

