using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public float maxHealth;
    public float currentHealth;

    public float damage;

    public float oldDamage;
    public float newDamage; 

    public Slider healthBar; 

    // Start is called before the first frame update
    void Start()
    {

        healthBar.maxValue = maxHealth;
        currentHealth = maxHealth;

        oldDamage = damage; 
        
    }

    // Update is called once per frame
    void Update()
    {

        healthBar.value = currentHealth; 

    }

    public void takeDamage()
    {

        currentHealth -= damage; 

    }

    public void blockDamage()
    {

        damage = newDamage; 

    }

    public void noblockDamage()
    {
        damage = oldDamage; 

    }


}
