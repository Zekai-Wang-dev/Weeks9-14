using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ManageButton : MonoBehaviour
{
    //Variables for the attack button so that the players could use it to attack the enemy. 
    public Button attackButton;
    public bool attacking; 

    public UnityEvent attackEvent; 

    // Start is called before the first frame update
    void Start()
    {
        attacking = false; 
        attackButton.onClick.AddListener(startAttack);

    }

    // Update is called once per frame
    void Update()
    {

        


    }

    public void startAttack()
    {
        //Invokinng the attack event so that the animation starts for the players to see. 
        attackEvent.Invoke();

    }

    public void changeCurrentState()
    {
        //This is to change the state of a boolean and add and remove the listeners to the buttons so that the players can't press them multiple times. 
        attacking = !attacking;

        if (attacking)
        {
            attackButton.onClick.RemoveAllListeners();

        }
        else
        {
            attackButton.onClick.AddListener(startAttack);
        }

    }


}
