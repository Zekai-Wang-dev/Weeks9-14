using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneTemplate;
using UnityEngine;

public class PlayerIdle : MonoBehaviour
{
    //All the initiation of the variables
    public Transform plrTrans;

    //An animation curve for the idle animation moving up and down
    public AnimationCurve curve;

    //Get the original position so that the player could return to its original position
    public Vector3 oldPos; 

    //time variable to allow animation to flow
    public float t;

    //Coroutines to start the animation
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

    //Method to start the coroutine to the idle animation so that it shows up when players start the game. 
    public void startIdleAnim()
    {

        startIdle = StartCoroutine(idling1());

    }

    //Stop the idle animation when the attack animation is playing so that they don't overwhelm eachother, it also doesn't make sense for idle animation to occur at the same time as attack. 
    public void stopIdle()
    {
        //Potential for the coroutine to be null so checking just in case. 
        if (startIdle != null)
        {
            StopCoroutine(startIdle);

        }

        if (startIdle2 != null)
        {
            StopCoroutine(startIdle2);

        }

        //Set back the original position so that the players starts attacking animation in the right position and not while in the air, which would appear weird. 
        plrTrans.position = oldPos;

    }

    //THe IEnumerator that starts the animation so that the player could  be seen idling
    public IEnumerator idling1()
    {
        //Reset the timer to zero so that it doens't start at the end. 
        t = 0f; 

        //Original position again just in case the player character is in a weird position when starting idling. 
        oldPos = plrTrans.position;

        //Make the player go up and down so that the player is doing a little idle animation 
        while (plrTrans.position != new Vector3(oldPos.x, oldPos.y + 0.2f, oldPos.z))
        {
            //Increase the time variable so that the animation could run 
            t += Time.deltaTime; 

            //Lerp the position which is where the player actually goes up
            plrTrans.position = Vector3.Lerp(oldPos, new Vector3(oldPos.x, oldPos.y + 0.2f, oldPos.z), curve.Evaluate(t));

            yield return 0; 
        }

        //Start the second idle animation which is basically making the player go back down, so that they don't go up infinitly
        startIdle2 = StartCoroutine(idling2());

    }

    //The IEnumerator that starts the second animation of the player going back down 
    public IEnumerator idling2()
    {
        //Reset the timer to zero so that it doesn't start at the end.
        t = 0f;

        //Make the player go down so that the player is doing a little idle animation. 
        while (plrTrans.position != oldPos) 
        {
            //Increase the time variable so that the animation could run. 
            t += Time.deltaTime; 

            //Lerp the position which is where the player actually goes up
            plrTrans.position = Vector3.Lerp(new Vector3(oldPos.x, oldPos.y + 0.2f, oldPos.z), oldPos, curve.Evaluate(t));

            yield return 0;

        }

        //Go back to the first animation to begin the loop again so that the idle animation doesn't only play once. 
        startIdle = StartCoroutine(idling1());

    }

}
