using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform transform; 

    public List<Vector3> posList;

    public AnimationCurve curve; 

    public Vector3 newPos;
    public Vector3 oldPos; 

    public float t; 

    public float speed;

    public bool moving;

    public LineRenderer lineR; 

    Coroutine playerMoving;
    Coroutine movingtoLocation;

    private void Awake()
    {

        lineR = GetComponent<LineRenderer>();
        transform = GetComponent<Transform>();

    }

    // Start is called before the first frame update
    void Start()
    {
        moving = false;
        movingtoLocation = StartCoroutine(playerMoved());

    }

    // Update is called once per frame
    void Update()
    {

        t += Time.deltaTime; 

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0; 

        if (Input.GetMouseButtonDown(0))
        {
            t = 0f; 
            newPos = Camera.main.ScreenToWorldPoint(mousePos);
            oldPos = transform.position; 
            newPos.z = 0;
            posList.Add(newPos);
            if (movingtoLocation != null)
            {
                StopCoroutine(movingtoLocation);

            }
            movingtoLocation = StartCoroutine(playerMoved());

        }

        lineR.SetPosition(0, oldPos);
        lineR.SetPosition(1, transform.position);


    }
    int i = 0;

    public IEnumerator playerMoved()
    {
        while (posList.Count > 0 && moving == false)
        {
            Debug.Log(posList[0]);
            t = 0f; 
            for (int i = 0; i < posList.Count; i++)
            {
                oldPos = transform.position; 
                yield return StartCoroutine(moveToLocation(posList[i]));

            }

        }
    }


    public IEnumerator moveToLocation(Vector3 newPos)
    {

        while (Vector3.Distance(transform.position, newPos) > 0.1)
        {
            moving = true; 
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, newPos, curve.Evaluate(t) * speed);
            yield return 0;
            Debug.Log("moving");

        }
        posList.RemoveAt(0);
        t = 0f;
        Debug.Log("arrived");

        moving = false; 
    }

}
