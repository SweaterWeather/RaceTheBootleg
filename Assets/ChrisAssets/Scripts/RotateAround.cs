using UnityEngine;
using System.Collections;


/// <summary>
/// This script makes the main menu planets orbit around the sun.
/// </summary>
public class RotateAround : MonoBehaviour {

    /// <summary>
    /// This is the degree by which the planet will rotate.
    /// </summary>
    float rotationAmount;

	/// <summary>
    /// This is the start function, it sets random rotational values for all components.  It also skews them slightly.
    /// </summary>
	void Start () {
        rotationAmount = Random.Range(-360, 360f);
        transform.eulerAngles = new Vector3(Random.Range(-5, 5f), 0, Random.Range(-5, 5f));
	}
	
	/// <summary>
    /// This is the update loop, it actually rotates the stupid planets.
    /// </summary>
	void Update () {
        transform.localEulerAngles += new Vector3(0, rotationAmount * Time.deltaTime /2, 0);
	}
}
