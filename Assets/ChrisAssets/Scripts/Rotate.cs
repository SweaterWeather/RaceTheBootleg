using UnityEngine;
using System.Collections;

/// <summary>
/// This script causes the attached game object to rotate by the rotationAmmount automatically.
/// </summary>
public class Rotate : MonoBehaviour {

	/// <summary>
    /// This is the ammount that the object will rotate by every frame.
    /// </summary>
	public Vector3 rotationAmmount;
	
	/// <summary>
    /// This is the update loop, it will rotate the object according to rotationAmmount;
    /// </summary>
	void Update () {
        transform.Rotate(rotationAmmount * Time.deltaTime);
	}
}
