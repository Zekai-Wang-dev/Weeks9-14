using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CarController : MonoBehaviour
{

    public Transform transform;
    public float speed;

    public bool turn;
    public bool stop; 

    private void Awake()
    {

        transform = GetComponent<Transform>();

    }

    // Start is called before the first frame update
    void Start()
    {
        turn = true;
        speed = 0.005f;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetMouseButtonDown(0))
        {
            stop = true; 
        }
        else if (Input.GetMouseButtonDown(1))
        {
            stop = false; 
        }
        */

        if (transform.position.x <= -9.36f)
        {

            turn = true; 

        }
        else if (transform.position.x >= 9.36f)
        {
            turn = false; 

        }


        if (turn == true && stop == false)
        {

            transform.Translate(speed, 0, 0);

        }
        else if (turn == false && stop == false)
        {
            transform.Translate(-speed, 0, 0);


        }

    }

    public void setGo()
    {
        stop = false; 

    }
    public void setStop()
    {
        stop = true; 
    }
}
