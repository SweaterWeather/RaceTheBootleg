using UnityEngine;
using System.Collections;

public class followPlayer : MonoBehaviour {
    public GameObject player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //light follows the player so the raycast emitter will always be aiming at player.
        transform.position = player.transform.position;
	}
}
