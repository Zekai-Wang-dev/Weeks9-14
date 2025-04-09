using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockButton : MonoBehaviour
{

    public Button blockButton;

    public GameObject shield; 

    // Start is called before the first frame update
    void Start()
    {

        blockButton.onClick.AddListener(blockAttack);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void blockAttack()
    {

        shield.SetActive(true);

    }

}
