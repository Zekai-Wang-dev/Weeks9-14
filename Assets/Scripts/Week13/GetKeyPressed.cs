using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;

public class GetKeyPressed : MonoBehaviour
{

    public int key;

    public UnityEvent<int> doSomethingWithKey; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < 10; i++)
        {

            if (Input.GetKey(i.ToString()))
            {

                key = i;
                doSomethingWithKey.Invoke(key);

                Debug.Log(i);

            }

        }

    }
}
