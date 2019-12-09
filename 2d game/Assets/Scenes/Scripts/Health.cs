using System.Collections;
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
    public bool GameOver = false;


    // Start is called before the first frame update
    void Start()
    {
        foreach (respawn_mechanic item in FindObjectsOfType<respawn_mechanic>())
        {
            item.OnHealthLoss += Respawn_Mechanic_OnHealthLoss;
            item.OnHealthGain += Respawn_Mechanic_OnHealthGain;
        }
    }

    private void Respawn_Mechanic_OnHealthLoss(object sender, System.EventArgs e)
    {
        healthHeart.sprite = hearts[health];
    }
    private void Respawn_Mechanic_OnHealthGain(object sender, System.EventArgs e)
    {
        healthHeart.sprite = hearts[health];
        Debug.Log("healed");
    }
    // Update is called once per frame
    void Update()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }
        if(health <= 0)
        {
            health = 0;
            //game over here
        }
       

    }

} 

   

