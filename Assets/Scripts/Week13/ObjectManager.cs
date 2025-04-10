using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{

    public List<GameObject> changingObjects; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enableObjects(int key)
    {

        if (key <= changingObjects.Count)
        {
            for (int i = 0; i < key; i++)
            {

                changingObjects[i].SetActive(true);

            }

            if (key != 0)
            {
                for (int i = changingObjects.Count - 1; i > key - 1; i--)
                {

                    changingObjects[i].SetActive(false);

                }
            }
            else
            {
                for (int i = 0; i < changingObjects.Count; i++)
                {

                    changingObjects[i].SetActive(false);

                }

            }


        }


    }

}
