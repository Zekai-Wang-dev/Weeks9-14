using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    //Variables for the enemy health so that the enemy's health could visibly decrease once an enemy attacks. 
    public float maxHealth;
    public float currentHealth;

    //The slider for the visuals to show the enemy that their health has decreased
    public Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        //Set the maxvalue of the slider to the maxhealth so that the slider understands where to start, also set the currenthealth to the maxhealth so that it starts from full. 
        healthBar.maxValue = maxHealth;
        currentHealth = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        //Set the value of the slider to the current health so that the enemys could see their health deplete. 
        healthBar.value = currentHealth;

    }

    //Method for the enemys to take damage so that they understand they are taking damage
    public void takeDamage(float damage)
    {
        //Decrease by the damage value set. 
        currentHealth -= damage;

    }

}
