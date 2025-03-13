using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TrafficLightsController : MonoBehaviour
{

    public GameObject redLight;
    public GameObject greenLight;

    public SpriteRenderer redlightSr;
    public SpriteRenderer greenLightSr; 

    public UnityEvent onLeftMouseClick;
    public UnityEvent onRightMouseClick; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            onLeftMouseClick.Invoke();

        }
        else if (Input.GetMouseButtonDown(1))
        {
            onRightMouseClick.Invoke();
        }
        
    }

    public void leftmouseClicked()
    {

        redlightSr.color = new Color(255, 0, 0);
        greenLightSr.color = new Color(0, 0, 0);

    }

    public void rightmouseClicked()
    {

        redlightSr.color = new Color(0, 0, 0);
        greenLightSr.color = new Color(0, 255, 0);

    }
}
