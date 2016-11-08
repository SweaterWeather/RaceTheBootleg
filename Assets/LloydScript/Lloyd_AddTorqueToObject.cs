using UnityEngine;
using System.Collections;

public class Lloyd_AddTorqueToObject : MonoBehaviour {
    Rigidbody rb;
    public Vector3 torque = new Vector3(0, 0, -50);
    public float range = 10;
    public GameObject player;
    bool doneAddTorque = false;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
       
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        float dis = transform.position.z - player.transform.position.z;
        if (dis < range && !doneAddTorque) { rb.AddTorque(torque); doneAddTorque = true; }
    }
}
