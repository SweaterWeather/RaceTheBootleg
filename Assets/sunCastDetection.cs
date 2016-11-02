using UnityEngine;
using System.Collections;

public class sunCastDetection : MonoBehaviour {

    public GameObject rayCaster;

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
                //The player was HIT! Do something.
                print(hit.collider.gameObject.name);
                //Drain ship energy!
                //need to work on ship speed controls with the objects before continuing this.
            }
            
        }
        //Debug.DrawRay(rayCaster.transform.position, -rayCaster.transform.forward * 600, Color.red); //raycast visualiser.
        Debug.DrawLine(rayCaster.transform.position, hit.point, Color.red);
	}
}
