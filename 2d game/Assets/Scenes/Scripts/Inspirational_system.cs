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
                inspiration.text = "For the MOTHERLAND!";
                QuoteTimer = 0;
                inspire = false;
            }
            if (num == 2)
            {
                inspiration.text = "In USSR, physics obey OUR LAWS!";
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
                inspiration.text = "If USSR falls, everything is lost" +
                    "/n KEEP GOING!";
                QuoteTimer = 0;
                inspire = false;
            }
            if (num == 5)
            {
                inspiration.text = "Continue, or be sent to the GULAG";
                QuoteTimer = 0;
                inspire = false;
            }
            if (num == 6)
            {
                inspiration.text = "The Nazi`s are INFERIOR" +
                    "/n USSR IS SUPERIOR";
                QuoteTimer = 0;
                inspire = false;
            }
            if (num == 7)
            {
                inspiration.text = "Nazi`s want to kill our women and children" +
                    "/n ARE YOU GOING TO ALLOW THEM?!";
                QuoteTimer = 0;
                inspire = false;
            }
            if (num == 8)
            {
                inspiration.text = "Vodka";
                QuoteTimer = 0;
                inspire = false;
            }
            if (num == 9)
            {
                inspiration.text = "fkers";
                QuoteTimer = 0;
                inspire = false;
            }
        }


    }
    void Random_pos()
    {

        if (QuoteTimer > maxQuoteTime)
        {
            num = (Random.Range(0, 10));
        }
    }
}
