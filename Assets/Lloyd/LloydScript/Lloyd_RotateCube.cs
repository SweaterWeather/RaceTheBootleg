using UnityEngine;
using System.Collections;
/// <summary>
/// rotating a gameobject
/// </summary>
public class Lloyd_RotateCube : MonoBehaviour {
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
    /// <summary>
    /// the final rotation
    /// </summary>
    int finalRotation = 270;
    /// <summary>
    /// the speed of the rotation;
    /// </summary>
    public float speed = 1;
    
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float dis = transform.position.z - player.transform.position.z;
        if (dis < range && !finAni)
        {
            float x = transform.localEulerAngles.x;
            float y = transform.localEulerAngles.y;
            float z = transform.localEulerAngles.z - Time.deltaTime * speed;
             if(z < finalRotation && z>finalRotation-10)
            {
                z = finalRotation;
                finAni = true;
            }
            
           
            transform.localEulerAngles = new Vector3(x,y,z);
        }
    }
}
