using UnityEngine;
using System.Collections;

public class SunController : MonoBehaviour {

    float angle;
    float angleTick = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        angle = 10 * Mathf.Sin(angleTick) + 7;
        angleTick = (staticController.speed / 100 -1.25f);
        float _angle = angle * (180 / Mathf.PI);

        Vector3 rotationVector = transform.rotation.eulerAngles;
        rotationVector.x = angle;

        transform.rotation = Quaternion.Euler(rotationVector);
	}
}
