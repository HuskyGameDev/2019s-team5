using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth
{

    private bool triggered = false; // when false, allows object to call TakeDamage
    public int health = 100;        // global variable for the starting health of the player
    public int healthMax = 100;     // global variable for the maximum health the player can have 
    public int damageAmt = 25;      // global variable for the standard damage amount 

    public PlayerHealth(int healthMax)  
    {
        this.healthMax = healthMax;
        health = healthMax;
    }

    //gets the current level of health  
    public int getHealth()
    {
        return health;
    }

    // deals damage to the subject/player 
    public void damage(int damageAmount)
    {
        health -= damageAmount;             // subtract health 
        if (health < 0)
        {
            health = 0;
        }
    }

    // heals the subject
    public void heal(int healAmount)
    {
        health += healAmount;               // adds health
        if (health > healthMax)
        {
            health = healthMax;
        }
    }

    // method that will deal damage to the player when enemy collides with them
    void OnTriggerEnter(Collider col)
    {
        if(!triggered && (col.transform.tag == "enemy"))        //if player collides with enemies 
        {
            damage(damageAmt);                                  //deal damage to the player

            if(getHealth().Equals(0))                           //if health is 0 trigger game over screen
            {
                triggered = true;         
                                                                // needs to go to game end screen
            }
            Debug.Log(col.transform.name);

        }
    }



}