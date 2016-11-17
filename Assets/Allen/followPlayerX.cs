using UnityEngine;
using System.Collections;

public class followPlayerX : MonoBehaviour {
    /// <summary>
    /// player: reference to the player object for tracking purposes.
    /// </summary>
    public GameObject player;
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, 1200);
	}
}
