using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackAnimation : MonoBehaviour
{
    //All the variables for the animation of the enemy attacking so that the player understands that they has attacked
    public AnimationCurve moveCurve;
    public AnimationCurve swingCurve;

    public Transform transform;
    public SpriteRenderer plrSr;

    public Transform enemyTrans; 
    public SpriteRenderer enemySr;
    public Vector3 oldPos;

    public Transform handle;

    public float rotationZ;
    public Vector3 oldRotate; 

    public float t;

    public Coroutine atkAct;
    public Coroutine swingAct;
    public Coroutine returnAct;
    public Coroutine returnSwingAct;

    public UnityEvent enemyatkEvent;
    public UnityEvent disableEvent;
    public UnityEvent enemyTakeDamageEvent; 

    private void Awake()
    {
        //Getting the components so that the program understands which component that they should be using. 
        transform = GetComponent<Transform>();
        plrSr = GetComponent<SpriteRenderer>();

    }

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activateAttack()
    {

        atkAct = StartCoroutine(animateAttack());

    }

    public IEnumerator animateAttack()
    {
        //Invoking a disable event that disables all the buttons so that there is only one coroutine playing at a time. 
        disableEvent.Invoke();

        //Setting timer back to 0 and make the player move to the enemies location to begin its attack. 

        t = 0f; 
        oldPos = transform.position; 

        while (transform.position != enemyTrans.position)
        {
            t += Time.deltaTime; 
            transform.position = Vector3.Lerp(oldPos, enemyTrans.position, moveCurve.Evaluate(t));

            yield return 0; 
        }

        swingAct = StartCoroutine(animateSwing());

    }

    public IEnumerator animateSwing()
    {
        //Setting timer back to 0 and make the player swing its sword so that the player knows they have attacked

        oldRotate = handle.eulerAngles; 

        t = 0f; 
        while (rotationZ != -90f)
        {

            t += Time.deltaTime; 
            rotationZ = Mathf.Lerp(oldRotate.z, -90f, swingCurve.Evaluate(t));
            handle.eulerAngles = new Vector3(0, 0, rotationZ);

            yield return 0; 
        }

        returnAct = StartCoroutine(animateReturn());
        enemyTakeDamageEvent.Invoke();

    }

    public IEnumerator animateReturn()
    {
        //Setting timer back to 0 and make the player go back to its original position so that the character does not move infinitely. 

        t = 0f;
        oldPos = transform.position;

        while (transform.position != new Vector3(-6.94f, 0, 0))
        {
            t += Time.deltaTime;

            transform.position = Vector3.Lerp(oldPos, new Vector3(-6.94f, 0, 0), moveCurve.Evaluate(t));

            yield return 0;
        }

        returnSwingAct = StartCoroutine(swingReturn());

    }

    public IEnumerator swingReturn()
    {
        //Return the swinged sword back to its original position so that next time it swings, it's not in a awkward position. 

        oldRotate = handle.eulerAngles;

        t = 0f;
        while (rotationZ != 0f)
        {

            t += Time.deltaTime;
            rotationZ = Mathf.Lerp(oldRotate.z, 0f, swingCurve.Evaluate(t));
            handle.eulerAngles = new Vector3(0, 0, rotationZ);

            yield return 0;
        }

        //Invoke the enemy attack event so that the enemy has a chance to fight back. 
        enemyatkEvent.Invoke();

    }

}
