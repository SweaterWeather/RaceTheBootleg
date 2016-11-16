using UnityEngine;
using System.Collections;

public class followPlayer : MonoBehaviour {
    /// <summary>
    /// player: reference to the player object for tracking purposes.
    /// </summary>
    public GameObject player;
	
	
	// Update is called once per frame
	void Update () {
        //light follows the player so the raycast emitter will always be aiming at player.
        transform.position = player.transform.position;
	}
}
