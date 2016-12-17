using UnityEngine;
using System.Collections;

public class crashCheck : MonoBehaviour {

    /// <summary>
    /// This is our sound.
    /// </summary>
    public SoundController sound;

    /// <summary>
    /// This is a thing.
    /// </summary>
    public HudManager yo;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 temp = transform.position;
        temp.z += 1;
        Ray ray = new Ray(temp, Vector3.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, staticController.speed * Time.deltaTime * 1.5f))
        {
            print(staticController.shield);
            if (hit.collider.tag == "obstacle" && !staticController.shield && !staticController.dead)
            {
                if (HudManager.shieldCount > 0)
                {
                    SoundController.playHurt = true;
                    HudManager.shieldCount--;
                    staticController.shield = true;
                }
                else
                {
                    sound.PlayDeath();
                    if (yo) yo.GameOverMan();
                    staticController.dead = true;
                }
            }
            if (hit.collider.tag == "obstacle" && staticController.shield)
            {
                print("shielded!");
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1000, 0)); //if shield is active and hit object, push player up (to avoid getting sucked under map)
            }
        }

        Debug.DrawLine(temp, temp + new Vector3(0, 0, 1f), Color.red);
	}
}
