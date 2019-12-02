using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inspirational_system : MonoBehaviour
{
    public Text inspiration;
    int num;
    float QuoteTimer = 0f;
    public float maxQuoteTime = 3.5f;
    // Start is called before the first frame update
    void Start()
    {
        Random_pos();
    }

    // Update is called once per frame
    void Update()
    {
        QuoteTimer += Time.deltaTime;
        Random_pos();
        if (num==1)
        {
            inspiration.text = "For the MOTHERLAND!";
            
            Random_pos();
            QuoteTimer = 0;
        }
        if (num==2)
        {
            inspiration.text = "In USSR, physics obey OUR LAWS!";
            
            Random_pos();
            QuoteTimer = 0;
        }
        if (num==3)
        {
            inspiration.text = "USSR needs you, DONT GIVE UP!";
            
            Random_pos();
            QuoteTimer = 0;
        }
        if (num==4)
        {
            inspiration.text = "If USSR falls, everything is lost" +
                "/n KEEP GOING!";
           
            Random_pos();
            QuoteTimer = 0;
        }
        if (num==5)
        {
            inspiration.text = "Continue, or be sent to the GULAG";
           
            Random_pos();
            QuoteTimer = 0;
        }
        if (num == 6)
        {
            inspiration.text = "The Nazi`s are INFERIOR" +
                "/n USSR IS SUPERIOR";
          
            Random_pos();
            QuoteTimer = 0;
        }

        if (num==7)
        {
            inspiration.text = "Nazi`s want to kill our women and children" +
                "/n ARE YOU GOING TO ALLOW THEM?!";
         
            Random_pos();
            QuoteTimer = 0;
        }
        if (num==8)
        {
            inspiration.text = "Vodka";

            Random_pos();
            QuoteTimer = 0;
        }
        if (num==9)
        {
            inspiration.text = "fkers";
            Random_pos();
            QuoteTimer = 0;
        }

    }
    void Random_pos()
    {

        if (QuoteTimer > maxQuoteTime)
        {
            num = (Random.Range(0, 10));
        }
        //Debug.Log(QuoteTimer);
    }
}
