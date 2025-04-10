using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BlockButton : MonoBehaviour
{
    //Variables for the block button to function so that the player understands they are blocking. 
    public Button blockButton;

    public GameObject shield;

    public UnityEvent blockEvent;

    public bool blocking; 

    // Start is called before the first frame update
    void Start()
    {

        blocking = false; 
        blockButton.onClick.AddListener(blockAttack);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void blockAttack()
    {
        //Making the shield appear so that the player understands they are blocking. 
        shield.SetActive(true);
        blockEvent.Invoke();

    }

    public void changeCurrentState()
    {
        //Change the state of the boolean that control blocking so that the player can't press it multiple times, causing errors. 
        blocking = !blocking;

        if (blocking)
        {
            blockButton.onClick.RemoveAllListeners();

        }
        else
        {
            blockButton.onClick.AddListener(blockAttack);
        }

    }

}
