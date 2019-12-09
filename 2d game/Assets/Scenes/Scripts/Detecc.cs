using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detecc : MonoBehaviour
{
    GameObject detecc;
    public bool switched = false;
    public bool pass = false;
    // Start is called before the first frame update
    void Start()
    {
        detecc = GameObject.FindWithTag("Respawn");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!pass)
        {
            if (other.gameObject.name.Equals("Detecc"))
            {
                pass = true;
                switched = true;
                Debug.Log("collision");
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

            if (collision.gameObject.name.Equals("Detecc"))
            {
                pass = false;
            }
        
    }
}
