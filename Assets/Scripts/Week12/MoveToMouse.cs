using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MoveToMouse : MonoBehaviour
{
    public Transform transform;
    public SpriteRenderer plrSprite;

    public AudioSource audioSource; 

    public Vector3 mousePos;

    public TilemapRenderer grassTile;
    public TilemapRenderer stoneTile;

    public List<SpriteRenderer> stoneSr; 

    public float speed;
    public float t;

    public AnimationCurve curve;

    public Animator animator;

    public AnimationClip clip; 

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        plrSprite = GetComponent<SpriteRenderer>();
        transform = GetComponent<Transform>();
        animator = GetComponent<Animator>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void playFootstepAudio()
    {
        for (int i = 0; i < stoneSr.Count; i++)
        {
            if (stoneSr[i].bounds.Contains(transform.position))
            {

                audioSource.Play();

            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime * speed; 

        if (Input.GetMouseButtonDown(0))
        {
            t = 0f; 

            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

        }

        if (transform.position != mousePos)
        {
            animator.SetBool("moving", true);

        }
        else
        {
            animator.SetBool("moving", false);

        }

        if (transform.position.x > mousePos.x)
        {
            plrSprite.flipX = true; 
        }
        else if (transform.position.x < mousePos.x)
        {
            plrSprite.flipX = false; 
        }

        for (int i = 0; i < stoneSr.Count; i++)
        {
            if (stoneSr[i].bounds.Contains(mousePos))
            {
                transform.position = Vector3.Lerp(transform.position, mousePos, curve.Evaluate(t));

            }

        }


    }
}
