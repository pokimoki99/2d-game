using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public bool easy, medium, hard;
    // Start is called before the first frame update
    void Start()
    {
        easy = false;
        medium = false;
        hard = false;
    }
    public void DifficultySelect(int Difficulty)
    {
        if(Difficulty == 0)
        {
            easy = true;
            medium = false;
            Debug.Log("easy is true");
        }

        if(Difficulty == 1)
        {
            medium = true;
            easy = false;
            Debug.Log("medium is true");
        }
    }
   


    

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
