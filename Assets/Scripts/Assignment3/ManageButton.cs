using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ManageButton : MonoBehaviour
{

    public Button attackButton;

    public UnityEvent attackEvent; 

    // Start is called before the first frame update
    void Start()
    {

        attackButton.onClick.AddListener(startAttack);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startAttack()
    {

        attackEvent.Invoke();

    }


}
