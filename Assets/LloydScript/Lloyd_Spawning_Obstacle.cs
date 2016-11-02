using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Lloyd_Spawning_Obstacle : MonoBehaviour {
    bool startGame = false;

    List<Lloyd_ObstacleMovement> obstacles;
    public GameObject player;
    public float xDisFromPlayer = 1;
    public Lloyd_ObstacleMovement obs;
    public Lloyd_ObstacleMovement obs2;

    public int spawnLimit = 10;

    public float startZoneZ = 20;
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


    void startSpawnObs()
    {
        if (obstacles.Count < 1)
        {
            Lloyd_ObstacleMovement obj = (Lloyd_ObstacleMovement)Instantiate(obs, getLocation(), Quaternion.identity);
            obstacles.Add(obj);

        }
        else if (obstacles.Count < spawnLimit)
        {
            int rand = Random.Range(1, 3);
            switch (rand)
            {
                case 1:
                    spawnObs1();
                    break;
                case 2:
                    SpawnObs2();
                    break;
                case 3:
                    break;
            }
        }

        removeObstaclePassZ();
    }

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

    void SpawnObs2()
    {
        Lloyd_ObstacleMovement obj = (Lloyd_ObstacleMovement)Instantiate(obs2, getLocation(), Quaternion.identity);
        if (checkSurrounding(obj)) obstacles.Add(obj);
        else { Destroy(obj.gameObject); };
    }

    void spawnObs1()
    {
        Lloyd_ObstacleMovement obj = (Lloyd_ObstacleMovement)Instantiate(obs, getLocation(), Quaternion.identity);
        if (checkSurrounding(obj)) obstacles.Add(obj);
        else { Destroy(obj.gameObject); };
    }

    Vector3 getLocation()
    {
        Vector3 location;
        float x = Random.Range(player.transform.position.x - xDisFromPlayer, player.transform.position.x + xDisFromPlayer);
        float y = 0;
        float z = startZoneZ;
        location = new Vector3(x, y, z);

        return location;
    }

    void removeObstaclePassZ()
    {
        for (int i = (obstacles.Count -1); i >= 0; i--)
        {
            
            if (obstacles[i].transform.position.z < deadZoneZ)
            {
                Destroy(obstacles[i].gameObject);
                obstacles.Remove(obstacles[i]);
                print("killed");
            }
        }

    }

    



}
