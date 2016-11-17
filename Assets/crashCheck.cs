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
            if(hit.collider.tag == "obstacle")
            {
                staticController.dead = true;
            }
        }

        Debug.DrawLine(transform.position, transform.position + new Vector3(0, 0, .75f), Color.red);
	}
}
