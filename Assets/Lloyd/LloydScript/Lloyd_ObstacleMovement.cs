using UnityEngine;
using System.Collections;

public class Lloyd_ObstacleMovement : MonoBehaviour {
    public float radius = 1;

    public Vector3 speed = new Vector3(0,0,10);
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        transform.position -= speed*Time.deltaTime;
	
	}
}
