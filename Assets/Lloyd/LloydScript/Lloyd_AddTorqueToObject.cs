using UnityEngine;
using System.Collections;
/// <summary>
/// This class plays the block animation to when the gameObject is close to the player
/// </summary>
public class Lloyd_AddTorqueToObject : MonoBehaviour {
    /// <summary>
    /// this is the reference to the animator componenet of the gameObject
    /// </summary>
    Animator ani;
   /// <summary>
   /// whe the game object's and player's total distanct is less then this range the animation will play
   /// </summary>
    public float range = 10;
    /// <summary>
    /// reference to the player game object
    /// </summary>
    public GameObject player;
    /// <summary>
    /// check to see if the animation is played
    /// </summary>
    bool finAni = false;
	// Use this for initialization
	void Start () {
        ani = GetComponent<Animator>();

       
	}
	
	// Update is called once per frame
	void Update () {
        float dis = transform.position.z - player.transform.position.z;
        if (dis < range && !finAni) { finAni = true; ani.SetTrigger("RotationTime"); print("eeee"); }
    }

    
}
