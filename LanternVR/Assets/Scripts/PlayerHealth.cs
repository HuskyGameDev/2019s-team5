namespace VRTK
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class PlayerHealth : MonoBehaviour
    {

        private bool triggered = false; // when false, allows object to call TakeDamage
        public int health = 100;        // global variable for the starting health of the player
        public int healthMax = 100;     // global variable for the maximum health the player can have 
        //public int damageAmt = 25;      // global variable for the standard damage amount 
        private VRTK_HeadsetFade bloodFade;
        public Color bloodColor;
        public float fadeDuration;

        private void Awake()
        {
            bloodFade = GetComponent<VRTK_HeadsetFade>();
            bloodFade.Fade(Color.black, 0.01f);
            bloodFade.Unfade(1f);
            health = healthMax;
            bloodColor.a = 0f; //1f makes it fully visible, 0f makes it fully transparent.
        }

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
            bloodColor.a = Mathf.Pow((1f - (float)health / healthMax),2f);
            bloodFade.Fade(bloodColor, fadeDuration);

            if (health <= 0)
            {
                bloodFade.Fade(Color.black, 1f);
                SceneManager.LoadScene("Menu");
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
        /*void OnTriggerEnter(Collider col)
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
        }*/



    }
}