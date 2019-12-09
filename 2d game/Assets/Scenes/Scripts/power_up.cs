using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class power_up : MonoBehaviour
{
    public GameObject player;
    public GameObject tank_power_up;
    //public GameObject tank_power_up_glow;
    public GameObject tank;
    public SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            // Change the 'color' property of the 'Sprite Renderer'
            sprite.color = new Color(1, 1, 1, 1);
            Debug.Log("change color");
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            // Change the 'color' property of the 'Sprite Renderer'
            sprite.color = new Color(1, 1, 1, 0);
            Debug.Log("change color");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("player"))
        {
            GameObject.Find("tank").GetComponent<Renderer>().enabled = true;
            GameObject.Find("player").GetComponent<Renderer>().enabled = false;
            Debug.Log("collide with player");
        }
        Debug.Log("collision");
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("player"))
        {
            GameObject.Find("tank").GetComponent<Renderer>().enabled = false;
            GameObject.Find("player").GetComponent<Renderer>().enabled = true;
            Debug.Log("collide with player");
        }
        Debug.Log("collision");
    }
}
