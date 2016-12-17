using UnityEngine;
using System.Collections;
/// <summary>
/// this class move the gameObject from z position to z negative
/// </summary>
public class Lloyd_ObstacleMovement : MonoBehaviour {
    /// <summary>
    /// The radius of the object
    /// </summary>
    public float radius = 1;

    Vector3 speed = new Vector3(0,0,staticController.speed);
	// Use this for initialization
	void Start () {

	}
	
	/// <summary>
    /// Movement is handeled here.
    /// </summary>
	void FixedUpdate () {
        speed = new Vector3(0, 0, staticController.speed);
        transform.position -= speed*Time.deltaTime;
	
	}
    
}
