using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacles : MonoBehaviour
{
    public GameObject obstacle;


    // Start is called before the first frame update
    void Start()
    {
        obstacle = GameObject.FindGameObjectWithTag("obstacles");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
