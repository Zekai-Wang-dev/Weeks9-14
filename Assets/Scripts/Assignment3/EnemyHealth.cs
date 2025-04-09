using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {

        healthBar.maxValue = maxHealth;
        currentHealth = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {

        healthBar.value = currentHealth;

    }

    public void takeDamage(float damage)
    {

        currentHealth -= damage;

    }

}
