using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EventsDemo : MonoBehaviour
{

    public RectTransform banana;
    public Button button;

    public UnityEvent OnTimerHasFinished;

    public float timerLength;
    public float t;

    // Update is called once per frame
    void Update()
    {

        t += Time.deltaTime;

        if (t > timerLength)
        {
            OnTimerHasFinished.Invoke();
            t = 0; 

        }

    }
    public void MouseJustEnteredImage()
    {
        Debug.Log("The mouse just entered the image!");
        banana.localScale = Vector3.one * 1.2f; 
    }

    public void MouseJustExitedImage()
    {
        Debug.Log("The mouse just exited the image!");
        banana.localScale = Vector3.one; 

    }

    // Start is called before the first frame update
    void Start()
    {
        timerLength = 3f; 
    }


}
