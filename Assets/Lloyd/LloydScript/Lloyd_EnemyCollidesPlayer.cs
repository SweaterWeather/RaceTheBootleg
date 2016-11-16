using UnityEngine;
using System.Collections;
/// <summary>
/// check if object collide with player
/// </summary>
public class Lloyd_EnemyCollidesPlayer : MonoBehaviour {
    
	// Use this for initialization
	void OnTriggerEnter(Collider obj)
    {
       
            print("game over");
        
    }
}
