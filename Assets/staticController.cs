using UnityEngine;
using System.Collections;

public class staticController : MonoBehaviour {

    /// <summary>
    /// float speed: variable that dictates the speed in which the player appears to be moving. This variable affects the sun's position in the sky and the speed in which all obstacles move towards the player.
    /// </summary>
    public static float speed = 100; // controls speed along the Z axis of all objects.
    public static bool dead = false; //is the player dead?
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (!dead)
        {
            if (speed > 150) speed = 150; //speed cap
            if (speed < 0) speed = 0; //min speed cap
        }
        else speed = 0; //player is dead. Kill the speed.
        
	}
}
