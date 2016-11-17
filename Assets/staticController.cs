using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class staticController : MonoBehaviour {

    /// <summary>
    /// float speed: variable that dictates the speed in which the player appears to be moving. This variable affects the sun's position in the sky and the speed in which all obstacles move towards the player.
    /// </summary>
    public static float speed = 50; // controls speed along the Z axis of all objects.
    public static bool dead = false; //is the player dead?
    float deadTimer = 100;

    public static bool boost = false;
    float boostTimer = 10;

    public static bool shield = false;
    float shieldTimer = 60;
    
	void resetClass()
    {
        speed = 50;
        dead = false;
        deadTimer = 100;
        boost = false;
        boostTimer = 10;
        shield = false;
        shieldTimer = 60;
    }
	// Update is called once per frame
	void Update () {

        if (!dead)
        {
            if (speed > 150) speed = 150; //speed cap
            if (speed < 0)
            {
                speed = 0;
                dead = true;
            }//min speed cap


            if (boost)
            {
                speed += 10 * Time.deltaTime;
                boostTimer -= Time.deltaTime * 15;

                if (boostTimer < 0) boost = false;
            }
            else boostTimer = 10;

            if (shield) //shield is active
            {
                shieldTimer -= Time.deltaTime * 15;
                print(shieldTimer);
                if (shieldTimer < 0) shield = false;
            }
            else shieldTimer = 60;
        }
        else
        {
            speed = 0; //player is dead. Kill the speed.
            deadTimer -= Time.deltaTime * 15;
            if(deadTimer <= 0)
            {
                resetClass();
                SceneManager.LoadScene("mainMenu");                
            }
        }
    }
}
