using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateObject : MonoBehaviour
{

    public Transform transform;

    public Coroutine moving;

    public float t;

    public AnimationCurve curve;

    public Vector3 originalPos;
    public Vector3 newPos;

    private void Awake()
    {

        transform = GetComponent<Transform>();

    }

    // Start is called before the first frame update
    void Start()
    {

        originalPos = transform.position; 
        
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void startTranslating(int key)
    {

        moving = StartCoroutine(transition(key));

    }

    public IEnumerator transition(int key)
    {
        t = 0f; 
        newPos = new Vector3(originalPos.x + key, originalPos.y, originalPos.z);

        while (transform.position != newPos)
        {
            t += Time.deltaTime; 
            transform.position = Vector3.Lerp(originalPos, newPos, curve.Evaluate(t));

            yield return 0;
        }


    }

    

}
