using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //Variables for the player so that they could see their health on screen for the health slider
    public float maxHealth;
    public float currentHealth;

    //A damage variable so that later I could change the variable when the player presses the block button. 
    public float damage;

    //Getting the new damage which is the damage after the player blocks so that they get less damage to their health, and old damage to return the damage to original so that the player doesn't become immortal
    public float oldDamage;
    public float newDamage; 

    //The healthbar slider to insert all the values so that the players could see their current health. 
    public Slider healthBar; 

    // Start is called before the first frame update
    void Start()
    {
        //Setting all the max values and current health to the max so that it starts at max when program starts. 
        healthBar.maxValue = maxHealth;
        currentHealth = maxHealth;

        //Setting the old damage to damage so that the damage could return back to normal later. 
        oldDamage = damage; 
        
    }

    // Update is called once per frame
    void Update()
    {
        //Set the value of the health bar to the current health so that the players could see what health they are at. 
        healthBar.value = currentHealth; 

    }

    public void takeDamage()
    {
        //Subtract the current health so that the players could understand that they have taken damage. 
        currentHealth -= damage; 

    }

    public void blockDamage()
    {
        //Change the damage to the new block damage so that the player could understand that they are blocking and the enemy did less damage to them. 
        damage = newDamage; 

    }

    public void noblockDamage()
    {
        //Return the damage to the original damage so that the player understands that they are not blocking anymore. 
        damage = oldDamage; 

    }


}
