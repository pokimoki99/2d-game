﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public int health;
    public int numOfHearts;

    public Sprite[] hearts;
    public Image healthHeart;
    public Sprite fullHearts;
    public Sprite emptyHearts;
    public respawn_mechanic respawn_Mechanic;


    // Start is called before the first frame update
    void Start()
    {
        foreach (respawn_mechanic item in FindObjectsOfType<respawn_mechanic>())
        {
            item.OnHealthLoss += Respawn_Mechanic_OnHealthLoss;
        }
    }

    private void Respawn_Mechanic_OnHealthLoss(object sender, System.EventArgs e)
    {
        healthHeart.sprite = hearts[health - 1];
    }

    // Update is called once per frame
    void Update()
    {

        if (health > numOfHearts)
        {
            health = numOfHearts;
        }
       
        //for (int i = 0; i < hearts.Length; i++)
        //{
        //    if (i < health)
        //    {
        //        hearts[i].sprite = fullHearts;
        //       // hearts[i].Destroy(false);
        //    }
        //    else
        //    {
        //        hearts[i].sprite = emptyHearts;
        //        //hearts[i].Destroy(true);
        //    }
        //    if(i < numOfHearts)
        //    {
        //        hearts[i].enabled = true;
        //    }
        //    else
        //    {
        //        hearts[i].enabled = false; 
        //    }
        //}

    }

} 

   

