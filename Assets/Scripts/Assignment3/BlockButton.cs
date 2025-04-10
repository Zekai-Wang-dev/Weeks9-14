using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BlockButton : MonoBehaviour
{

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

        shield.SetActive(true);
        blockEvent.Invoke();

    }

    public void changeCurrentState()
    {

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
