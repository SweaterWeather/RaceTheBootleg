using UnityEngine;
using System.Collections;

/// <summary>
/// This script starts the game.
/// </summary>
public class StartTheGame : MonoBehaviour {

    /// <summary>
    /// This is the starting difficulty.
    /// </summary>
    static public int startDiff;

    /// <summary>
    /// This is the obstacle spawner.
    /// </summary>
    public Lloyd_Spawning_Obstacle spawner;

	/// <summary>
    /// This startup sets every value that the game needs.
    /// </summary>
	void Start ()
    {
        switch (startDiff)
        {
            case 0:
                spawner.playerScore = 0;
                staticController.speed = 50;
                break;
            case 1:
                spawner.playerScore = 1000;
                HudManager.score = 1000;
                staticController.speed = 100;
                break;
            case 2:
                print("hard");
                spawner.playerScore = 2000;
                HudManager.score = 2000;
                staticController.speed = 150;
                break;
        }
        HudManager.maxJump = 1;
        HudManager.maxShield = 1;

        staticController.dead = false;

    }
}
