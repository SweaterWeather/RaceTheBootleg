using UnityEngine;
using System.Collections;

public class Lloyd_Rotator : MonoBehaviour {

    // Use this for initialization
    /// <summary>
    /// the gameObject that the player controls
    /// </summary>
    public GameObject player;
    /// <summary>
    /// the speed of the rotation
    /// </summary>
    public float speed = 1000f;
        
    /// <summary>
    /// the final degree turn
    /// </summary>
    public float doneRotationZ = 0;
    /// <summary>
    /// the zDistance when the gameObect is close to the player
    /// </summary>
    public int distanceFromPlayer = 10;
    /// <summary>
    /// the rotation in z direction;
    /// </summary>
   
    bool isDone = false;
	void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
        float dis = transform.position.z - player.transform.position.z;
        if(dis < distanceFromPlayer && !isDone)
        {
            
            if (transform.localEulerAngles.z > doneRotationZ) {
                float x = transform.localEulerAngles.x;
                float y = transform.localEulerAngles.y;
               float z = transform.localEulerAngles.z - Time.deltaTime * speed;
                if (z > 270)
                {
                    z = 0;
                    isDone = true;
                }
                transform.localEulerAngles = new Vector3(x, y, z);
                
            }
            
        }
	
	}
}
