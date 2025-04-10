using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RotatingObject : MonoBehaviour
{

    public Transform transform;

    public float t;

    public Vector3 oldRotate; 

    public AnimationCurve curve;

    public Coroutine startRotate;

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
        
    }


    public void rotateInKey(int key)
    {

        startRotate = StartCoroutine(rotating(key));

    }

    public IEnumerator rotating(int key)
    {
        t = 0f;

        oldRotate = transform.eulerAngles;

        while (transform.eulerAngles != new Vector3(0, 0, key * 10)) 
        {
            t += Time.deltaTime; 
            transform.eulerAngles = Vector3.Lerp(oldRotate, new Vector3(0, 0, key * 10), curve.Evaluate(t));

            yield return 0; 
        }



    }

}
