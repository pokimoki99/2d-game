using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class power_up : MonoBehaviour
{
    public GameObject player;
    public GameObject tank_power_up;
    public GameObject tank;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("player"))
        {
            //GameObject.Find("tank").renderer.enabled = true;
            //GameObject.Find("player").renderer.enabled = false;
            Debug.Log("collide with player");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {

    }
}
