using UnityEngine;
using System.Collections;

public class crashCheck : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = new Ray(transform.position, Vector3.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, .75f))
        {
            if(hit.collider.tag == "obstacle" && !staticController.shield)
            {
                staticController.dead = true;
            }
            if (hit.collider.tag == "obstacle" && staticController.shield)
            {
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1000, 0)); //if shield is active and hit object, push player up (to avoid getting sucked under map)
            }
        }

        Debug.DrawLine(transform.position, transform.position + new Vector3(0, 0, .75f), Color.red);
	}
}
