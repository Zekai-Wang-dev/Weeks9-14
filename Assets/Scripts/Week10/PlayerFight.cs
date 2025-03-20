using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{

    public float t;

    public AnimationCurve curve; 

    public GameObject player1;
    public GameObject player2;

    public Transform player1Trans;
    public Transform player2Trans;

    public UnityEvent Plr1AttackFinish;
    public UnityEvent Plr2AttackFinish;

    Coroutine player1Fight;
    Coroutine player2Fight;

    private void Awake()
    {
        player1Trans = player1.GetComponent<Transform>();
        player2Trans = player2.GetComponent<Transform>();

    }

    // Start is called before the first frame update
    void Start()
    {

        //player1Fight = StartCoroutine(player1Fought());
        //player2Fight = StartCoroutine(player2Fought());

    }

    public IEnumerator player1Fought()
    {
        t = 0; 
        while (t < 2)
        {
            t += Time.deltaTime;
            player1Trans.position = Vector3.Lerp(player1Trans.position, new Vector3(-4.64f, 2.91f, 0), curve.Evaluate(t));
            yield return null;

        }

        while (t > 2 && t < 4)
        {
            t += Time.deltaTime;
            player1Trans.position = Vector3.Lerp(player1Trans.position, new Vector3(-4.64f, -2.69f, 0), curve.Evaluate(t));
            Plr1AttackFinish.Invoke();

            yield return null;

        }

    }

    public IEnumerator player2Fought()
    {
        t = 0;
        while (t < 2)
        {
            t += Time.deltaTime;
            player2Trans.position = Vector3.Lerp(player2Trans.position, new Vector3(4.53f, 2.91f, 0), curve.Evaluate(t));
            yield return null;

        }

        while (t > 2 && t < 4)
        {
            t += Time.deltaTime;
            player2Trans.position = Vector3.Lerp(player2Trans.position, new Vector3(4.53f, -2.69f, 0), curve.Evaluate(t));
            Plr2AttackFinish.Invoke();

            yield return null;

        }

    }

    public void startPlayer1Attack()
    {
        player1Fight = StartCoroutine(player1Fought());

    }

    public void startPlayer2Attack()
    {
        player2Fight = StartCoroutine(player2Fought());

    }



}
