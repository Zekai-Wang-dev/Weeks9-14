using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackAnimation : MonoBehaviour
{
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
        disableEvent.Invoke();

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

        oldRotate = handle.eulerAngles;

        t = 0f;
        while (rotationZ != 0f)
        {

            t += Time.deltaTime;
            rotationZ = Mathf.Lerp(oldRotate.z, 0f, swingCurve.Evaluate(t));
            handle.eulerAngles = new Vector3(0, 0, rotationZ);

            yield return 0;
        }

        enemyatkEvent.Invoke();

    }

}
