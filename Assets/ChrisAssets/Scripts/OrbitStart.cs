using UnityEngine;
using System.Collections;

/// <summary>
/// This script animates the opening planet swinging around the sun and slowing to a stop in front of the camera.
/// </summary>
public class OrbitStart : MonoBehaviour {

    /// <summary>
    /// This marks the rate at which the planet will orbit.
    /// </summary>
    public Vector3 rotationAmmount;

    /// <summary>
    /// This is the point that the planet's orbit will stop at.
    /// </summary>
    public Vector3 stopPosition;

    /// <summary>
    /// This is the point the planet will start at.
    /// </summary>
    public Vector3 startPosition;

	/// <summary>
    /// This is the startup function, it simply sets the stop position equal to the current position.
    /// </summary>
	void Start () {
        stopPosition = transform.localEulerAngles;

        transform.localEulerAngles = startPosition;
	}
	
	/// <summary>
    /// This is the update loop, it actually rotates the stupid planet.
    /// </summary>
	void Update () {
        rotationAmmount = new Vector3((stopPosition.x - transform.localEulerAngles.x), 0, 0);
        transform.Rotate(rotationAmmount * Time.deltaTime * 2);
        if (transform.localEulerAngles.x > stopPosition.x) transform.localEulerAngles = stopPosition;
	}
}
