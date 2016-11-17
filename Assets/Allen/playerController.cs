using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

    /// <summary>
    /// body: stores a reference to a rigid body to apply physics to.
    /// thrust: used to help apply force to allow player to strafe left and right.
    /// angle: used to rotate the ship based on strafe
    /// </summary>
    Rigidbody body;
    public float thrust = 20;
    float angle;


	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody>(); //the rigidbody on the object this script is attached to.
	}
	
	// Update is called once per frame (I have two update loops because the GetButtonDown function does not work properly in FixedUpdate, likely because you would have to hit the button exactly when Fixed update runs which is not every frame.)
    void Update()
    {
        if (!staticController.dead)
        {

            if (Input.GetButtonDown("Jump"))
            {
                //print("jump");
                body.AddForce(new Vector3(0, 3000, 0));//applies a force that allows player to jump
            }
        }
    }
	void FixedUpdate () { //Physics update
        if (!staticController.dead)
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                //depending on the axis value, strafe left or right.
                float _thrust = Input.GetAxis("Horizontal") * thrust;
                Vector3 force = new Vector3(_thrust, 0, 0);
                body.AddForce(force);

            }
            angle = -Input.GetAxis("Horizontal") * 80; //sets angle of player based on turn axis
            body.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
        else gameObject.GetComponent<Rigidbody>().isKinematic = true; //stops physics from applying to object

        

    }
}
