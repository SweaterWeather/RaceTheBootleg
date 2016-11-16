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
    /// <summary>
    /// the default speed of the object
    /// </summary>
    public Vector3 speed = new Vector3(0,0,10);
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        transform.position -= speed*Time.deltaTime;
	
	}
}
