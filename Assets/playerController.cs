using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

    Rigidbody body;
    public float thrust = 20;
    float angle;


	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetAxis("Horizontal") != 0)
        {
            float _thrust = Input.GetAxis("Horizontal") * thrust;
            Vector3 force = new Vector3(_thrust, 0, 0);
            body.AddForce(force);
            
            
        }
        angle = -Input.GetAxis("Horizontal") * 80;
        body.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

    }
}
