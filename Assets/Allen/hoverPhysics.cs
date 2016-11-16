using UnityEngine;
using System.Collections;

public class hoverPhysics : MonoBehaviour {

    /// <summary>
    /// _lPos: position being used by the Raycaster. This script is attached to a player object
    /// vertVel: vertical Velocity of player (how fast are they falling or rising)
    /// maxVel: the fastest the player can rise or fall.
    /// </summary>
    Vector3 _lPos;
    float vertVel;
    float maxVel = .25f;

    bool grounded = false;
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        RaycastHit hit;
        _lPos = transform.position + new Vector3(0, 0, .2f);
        Ray ray = new Ray(_lPos, Vector3.down);

        if (Physics.Raycast(ray, out hit, 1.25f)) //shots out a ray 1.25f units downwards,
        {
            //player is close to ground, push up
            
                
            if (hit.distance < 1.23) vertVel -= .005f; //velocity pushes up
            else vertVel *= .5f; //strong slowdown of velocity as its over a certain speed.

        }
        else
        {
            //player is FLYING GUYS.

            vertVel += .002f; //slow but steadily increasing decent speed.
            if (vertVel > maxVel) vertVel = maxVel; //caps the falling velocity if it passes a certain amount
        }



        //slowly lower back to floor       
        vertVel *= .99f;//constantly slightly reducing velocity no matter if falling or rising. Helped smooth transitions.
        if (Mathf.Abs(vertVel) < .0001f) vertVel = 0; //zero's out the speed if it gets to low (reduces jitter)
        transform.position += new Vector3(0, -vertVel, 0); //code that directly affects the player's verticle position.

        Debug.DrawLine(_lPos, _lPos - new Vector3(0, 1.25f, 0), Color.red); //debug code, only visible in editor.
	}
}
