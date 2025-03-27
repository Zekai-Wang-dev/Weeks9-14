using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public SpriteRenderer sr;
    public Transform transform; 

    public Animator animator;
    public float movement;
    public float speed;

    public bool attacking; 

    private void Awake()
    {
        transform = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

    }

    // Start is called before the first frame update
    void Start()
    {
        attacking = false;
    }

    // Update is called once per frame
    void Update()
    {

        movement = Input.GetAxis("Horizontal");

        sr.flipX = (movement < 0); 

        animator.SetFloat("movement", Mathf.Abs(movement));

        //transform.Translate(speed * movement, 0, 0);
        if (attacking == false)
        {
            transform.position += transform.right * movement * speed * Time.deltaTime;

        }

        if (Input.GetKeyDown(KeyCode.E))
        {

            animator.SetTrigger("attack");
            attacking = true; 

        }
        
    }

    public void attackEnd()
    {

        attacking = false; 
        Debug.Log("The attack animation just finished");

    }

}
