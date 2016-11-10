using UnityEngine;
using System.Collections;

public class hoverPhysics : MonoBehaviour {
    new Vector3 _lPos;
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

        if (Physics.Raycast(ray, out hit, 1.25f))
        {
            //player is close to ground 
            
                
            if (hit.distance < 1.23) vertVel -= .005f;
            else vertVel *= .5f;

        }
        else
        {
            //player is FLYING GUYS.

            vertVel += .002f;
            if (vertVel > maxVel) vertVel = maxVel;
        }



        //slowly lower back to floor           


        vertVel *= .99f;
        if (Mathf.Abs(vertVel) < .0001f) vertVel = 0;
        transform.position += new Vector3(0, -vertVel, 0);

        Debug.DrawLine(_lPos, _lPos - new Vector3(0, 1.25f, 0), Color.red);
	}
}
