using UnityEngine;
using System.Collections;

public class sunCastDetection : MonoBehaviour {

    public GameObject rayCaster;
    public GameObject _player;
    bool playerInSun = false; //oerhaps make this global in GameController?
	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    /// <summary>
    /// 
    /// </summary>
    void Update () {
        RaycastHit hit;
        Ray ray = new Ray(rayCaster.transform.position, -rayCaster.transform.forward);
                
        if (Physics.Raycast(ray, out hit))
        {
            //The raycast hit something
            if (hit.collider.tag == "Player")
            {
                _player = hit.collider.gameObject;
                playerInSun = true;
            }
            else playerInSun = false;            
        }

        //DEBUGGING CODE ------------------------------------------

        if (playerInSun) _player.GetComponent<MeshRenderer>().material.color = Color.green; //in Sun = Green
        else _player.GetComponent<MeshRenderer>().material.color = Color.red; //else Red


        //Debug.DrawRay(rayCaster.transform.position, -rayCaster.transform.forward * 600, Color.red); //raycast visualiser.
        Debug.DrawLine(rayCaster.transform.position, hit.point, Color.red);

        //END DEUBGGING CODE ------------------------------------------
    }
}
