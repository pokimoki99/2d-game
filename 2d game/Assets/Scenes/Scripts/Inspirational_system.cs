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
    public bool inspire = false;
    // Start is called before the first frame update
    void Start()
    {
        Random_pos();
    }

    // Update is called once per frame
    void Update()
    {
        QuoteTimer += Time.deltaTime;
        if (inspire==true)
        {
            Random_pos();
            if (num == 1)
            {
                inspiration.text = "The Germans are Advancing";
                QuoteTimer = 0;
                inspire = false;
            }
            if (num == 2)
            {
                inspiration.text = "You cannot make a revolution"+"/n with White gloves";
                QuoteTimer = 0;
                inspire = false;
            }
            if (num == 3)
            {
                inspiration.text = "USSR needs you, DONT GIVE UP!";
                QuoteTimer = 0;
                inspire = false;
            }
            if (num == 4)
            {
                inspiration.text = "If The USSR falls, everything is lost" +
                    "\n KEEP GOING!";
                QuoteTimer = 0;
                inspire = false;
            }
            if (num == 5)
            {
                inspiration.text = "The Russian people are" +
                    "\n depending on you";
                QuoteTimer = 0;
                inspire = false;
            }
            if (num == 6)
            {
                inspiration.text = "Never allow Nazis" +
                    "\n to march forward";
                QuoteTimer = 0;
                inspire = false;
            }
            if (num == 7)
            {
                inspiration.text = "Nazi`s have come to steal" +
                    "\n our women and children" +
                    "\n ARE YOU GOING TO ALLOW THEM?!";
                QuoteTimer = 0;
                inspire = false;
            }
        }


    }
    void Random_pos()
    {

        if (QuoteTimer > maxQuoteTime)
        {
            num = (Random.Range(0, 8));
        }
    }
}
