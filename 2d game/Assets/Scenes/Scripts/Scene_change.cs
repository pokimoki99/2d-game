using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_change : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            Debug.Log("touch");
            if (touch.phase == TouchPhase.Began)
            {
                Debug.Log("next scene");
                
            }
        }
    }
}
