using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToMouse : MonoBehaviour
{

    public Transform transform;

    public Vector3 mousePos; 

    private void Awake()
    {

        transform = GetComponent<Transform>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mousePos.z = 0;

        transform.up = mousePos - transform.position; 

    }
}
