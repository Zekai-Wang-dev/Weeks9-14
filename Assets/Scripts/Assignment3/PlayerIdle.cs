using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneTemplate;
using UnityEngine;

public class PlayerIdle : MonoBehaviour
{

    public Transform plrTrans;

    public AnimationCurve curve;

    public Vector3 oldPos; 

    public float t;

    public Coroutine startIdle;
    public Coroutine startIdle2;

    // Start is called before the first frame update
    void Start()
    {

        startIdle = StartCoroutine(idling1());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startIdleAnim()
    {

        startIdle = StartCoroutine(idling1());

    }

    public void stopIdle()
    {

        if (startIdle != null)
        {
            StopCoroutine(startIdle);

        }

        if (startIdle2 != null)
        {
            StopCoroutine(startIdle2);

        }

        plrTrans.position = oldPos;

    }

    public IEnumerator idling1()
    {
        t = 0f; 

        oldPos = plrTrans.position;

        while (plrTrans.position != new Vector3(oldPos.x, oldPos.y + 0.2f, oldPos.z))
        {

            t += Time.deltaTime; 

            plrTrans.position = Vector3.Lerp(oldPos, new Vector3(oldPos.x, oldPos.y + 0.2f, oldPos.z), curve.Evaluate(t));

            yield return 0; 
        }

        startIdle2 = StartCoroutine(idling2());

    }

    public IEnumerator idling2()
    {
        t = 0f;

        while (plrTrans.position != oldPos) 
        {

            t += Time.deltaTime; 

            plrTrans.position = Vector3.Lerp(new Vector3(oldPos.x, oldPos.y + 0.2f, oldPos.z), oldPos, curve.Evaluate(t));

            yield return 0;

        }

        startIdle = StartCoroutine(idling1());

    }

}
