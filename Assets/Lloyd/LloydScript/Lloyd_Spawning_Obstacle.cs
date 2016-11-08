using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// spawning script
/// </summary>
public class Lloyd_Spawning_Obstacle : MonoBehaviour {





    public float delaySpawn = 5;
    /// <summary>
    /// how hard is the level
    /// </summary>
  public  int difficulty = 0;
    /// <summary>
    /// score that the player earn
    /// </summary>
    public int playerScore = 0;
    /// <summary>
    /// a bool that init the game when it is true
    /// </summary>
    bool startGame = false;
    /// <summary>
    /// any obstacles that are instantiated go here
    /// </summary>
    List<Lloyd_ObstacleMovement> obstacles;
    /// <summary>
    /// the player of the game
    /// </summary>
    public GameObject player;
    /// <summary>
    /// The range of the obstacle to the player in x-axis
    /// </summary>
    public float xDisFromPlayer = 1;
    /// <summary>
    /// obstacle 1 that is easy to dodge
    /// </summary>
    public Lloyd_ObstacleMovement obs;
    /// <summary>
    /// extra obstacle for begins level
    
    /// </summary>
    public Lloyd_ObstacleMovement obs1_extra;
    /// <summary>
    /// onstcle 2 that is a bit harder to dodge
    /// </summary>
    
    public Lloyd_ObstacleMovement obs2;
    /// <summary>
    /// obstacle 3 that is
    /// </summary>
    public Lloyd_ObstacleMovement obs3;
    /// <summary>
    /// obstacle 4
    /// </summary>
    public Lloyd_ObstacleMovement obs4;
    /// <summary>
    /// the platform in the air that aid the player
    /// </summary>

    public Lloyd_ObstacleMovement flyingPlatform;
    /// <summary>
    /// maximum obstacle that is spawned on the screen
    /// </summary>
    public int spawnLimit = 10;
    /// <summary>
    /// where obstacles will be spawn on z axis
    /// </summary>
    public float startZoneZ = 20;
    /// <summary>
    /// where obstacles will be die on z axis
    /// </summary>
    public float deadZoneZ = -10;
	// Use this for initialization
	void Start () {
        obstacles = new List<Lloyd_ObstacleMovement>();
	}
	
	// Update is called once per frame
	void Update () {



        if (startGame)
        {
            startSpawnObs();
        }
        else
        {
            startGame = Input.GetButton("StartPlaying");
        }

	}

    /// <summary>
    /// spawning obstacle depending on which difficulty it is
    /// </summary>
    void startSpawnObs()
    {
        difficulty = (int)playerScore / 1000;
        int rnd = Mathf.Clamp(Random.Range(1, 5) + Random.Range(1, 5) + difficulty, 6, 10);
      
        if (obstacles.Count < 1)
        {
            Lloyd_ObstacleMovement obj = (Lloyd_ObstacleMovement)Instantiate(obs, getLocation(), Quaternion.identity);
            obstacles.Add(obj);

        }
        else if (obstacles.Count < spawnLimit)
        {
          
            switch (rnd)
            {
                case 6:
                    int rand = Random.Range(1, 3);
                    if(rand==1) spawnObs1(obs);
                   else if (rand == 2) spawnObs1(obs1_extra);
                    break;
                case 7:
                    spawnObs1(obs2);
                    break;
                case 8:
                    spawnObs1(obs3);
                    break;
                case 9:
                    spawnObs1(obs4);
                    break;
            }
        }

        spawnAirPlatForm();

        removeObstaclePassZ();
    }

    /// <summary>
    /// spawning air platform
    /// </summary>
    void spawnAirPlatForm()
    {

        int trnd = Random.Range(1, 5) + Random.Range(1, 5);
        if (delaySpawning())
        {
            switch (trnd)
            {
                case 6:
                    spawnObs1(flyingPlatform);
                    break;
                case 7:
                    spawnObs1(flyingPlatform);
                    break;
            }
        }
     
    }
    /// <summary>
    /// delaying the spawn of an obstacle
    /// </summary>
    /// <returns></returns>
    bool delaySpawning()
    {
        if (delaySpawn < 0)
        {
            delaySpawn = 5;
            return true;
         
        }
        else
        {
            delaySpawn -= Time.deltaTime;
            return false;
        }
    }
    /// <summary>
    /// before the object is spawned it needs to check is surrounding to see if it is conflict with any other obstacle
    /// if it is, the object will be destroyed
    /// </summary>
    /// <param name="obs">the spawning object reference</param>
    /// <returns></returns>
    bool checkSurrounding(Lloyd_ObstacleMovement obs)
    {
        Vector3 displacement;
        for (int i = (obstacles.Count - 1); i >= 0; i--)
        {
            displacement = obstacles[i].transform.position - obs.gameObject.transform.position;
            float totalRad = obstacles[i].radius + obs.radius;
           // print(i + " Radius " + totalRad + " displacementMag " +displacement.sqrMagnitude);
            if(displacement.sqrMagnitude < totalRad*totalRad)
            {
                return false;
            }
        }
        return true;
    }

   /* void SpawnObs2()
    {
        Lloyd_ObstacleMovement obj = (Lloyd_ObstacleMovement)Instantiate(obs2, getLocation(), Quaternion.identity);
        if (checkSurrounding(obj)) obstacles.Add(obj);
        else { Destroy(obj.gameObject); };
    }
    */

        /// <summary>
        /// the base function to spawn an object at certain location
        /// </summary>
        /// <param name="obsSpawn">the reference the object that is about to spawn</param>
    void spawnObs1(Lloyd_ObstacleMovement obsSpawn)
    {
        Lloyd_ObstacleMovement obj = (Lloyd_ObstacleMovement)Instantiate(obsSpawn, getLocation(), Quaternion.identity);
        if (checkSurrounding(obj)) obstacles.Add(obj);
        else { Destroy(obj.gameObject); };
    }
    /// <summary>
    /// setting the location of the spawing object
    /// </summary>
    /// <returns></returns>
    Vector3 getLocation()
    {
        Vector3 location;
        float x = Random.Range(player.transform.position.x - xDisFromPlayer, player.transform.position.x + xDisFromPlayer);
        float y = 0;
        float z = startZoneZ;
        location = new Vector3(x, y, z);

        return location;
    }
    /// <summary>
    /// if an object passed a certain z threshold it will be destroyed and remove from the array
    /// </summary>
    void removeObstaclePassZ()
    {
        for (int i = (obstacles.Count -1); i >= 0; i--)
        {
            
            if (obstacles[i].transform.position.z < deadZoneZ)
            {
                Destroy(obstacles[i].gameObject);
                obstacles.Remove(obstacles[i]);
                
            }
        }

    }

    



}
