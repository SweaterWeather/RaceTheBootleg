using UnityEngine;
using System.Collections;

public class sunCastDetection : MonoBehaviour {

    /// <summary>
    /// rayCaster: reference to the location we want to shoot the ray from. This position is based on the parenting to the directional light that affects the sun. Always between sun and player.
    /// _player: local copy of the player object, used in changing material of specific player based on if they are in the sun.
    /// playerInSun: a debugging variable that toggles the material of the player based on if they are in the sun or not. Green = in sun, Red = nope.
    /// </summary>
    public GameObject rayCaster;
    public GameObject _player;
    bool playerInSun = true;
    
	
    // Update is called once per frame
    /// <summary>
    /// RaycastHit hit: variable that returns what the cast hits. Used to see if the sun has a clear line of site with player.
    /// Ray ray: the ray we are firing from the Sun towards the player.
    /// </summary>
    void Update () {
        RaycastHit hit;
        Ray ray = new Ray(rayCaster.transform.position, -rayCaster.transform.forward);
                
        if (Physics.Raycast(ray, out hit))
        {
            //The raycast hit something
            if (hit.collider.tag == "Player") //the ray hit the player object
            {
                //_player = hit.collider.gameObject; //setting local copy of player based on the player that is hit by the ray (used for changing color of material from green to red)    
                playerInSun = true;            
                staticController.speed += 5 * Time.deltaTime; //increases player's speed as they are in the sun.
            }
            else //player is not in sunlight
            {
                playerInSun = false;
                staticController.speed -= 10 * Time.deltaTime; //slows player's speed as they are not in the sun                    
            }         
        }

        //DEBUGGING CODE ------------------------------------------
        //ONLY VISIBLE IN EDITOR
        if (playerInSun) _player.GetComponent<MeshRenderer>().material.color = Color.green; //in Sun = Green
        else _player.GetComponent<MeshRenderer>().material.color = Color.red; //else Red


        //Debug.DrawRay(rayCaster.transform.position, -rayCaster.transform.forward * 600, Color.red); //raycast visualiser.
        Debug.DrawLine(rayCaster.transform.position, hit.point, Color.red);

        //END DEUBGGING CODE ------------------------------------------
    }
}
