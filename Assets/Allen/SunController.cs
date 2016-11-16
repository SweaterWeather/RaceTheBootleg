using UnityEngine;
using System.Collections;

public class SunController : MonoBehaviour {

    /// <summary>
    /// angle: angle the dir light is pointing if the flat floor is 0 degrees.
    /// angleTick: used to set the position in the sin wave. Moves sun up and down.
    /// </summary>
    float angle;
    float angleTick = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        angle = 10 * Mathf.Sin(angleTick) + 7; //sets the rotation of the dir light, which in turn moves the sun up and down between the values listed.
        angleTick = (staticController.speed / 100 -1.25f); //sets position of sin wave based on speed. Higher the speed, higher the sun goes.
        float _angle = angle * (180 / Mathf.PI); //converts to degrees from radians

        Vector3 rotationVector = transform.rotation.eulerAngles; //sets Vector, equal to object this is attached to.
        rotationVector.x = angle; //sets the x rotation equal to the angle.

        transform.rotation = Quaternion.Euler(rotationVector); //rotates object based on the adjusted angle from above.
	}
}
