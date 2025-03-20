using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Button plr1Button;
    public Button plr2Button; 

    public void enablePlr1Attack()
    {
        plr1Button.enabled = true;
        plr2Button.enabled = false; 


    }

    public void enablePlr2Attack()
    {
        plr1Button.enabled = false;
        plr2Button.enabled = true; 

    }

}
