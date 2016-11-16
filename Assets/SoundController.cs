using UnityEngine;
using System.Collections;

/// <summary>
/// This script controls the sound effects and music of the game.
/// </summary>
public class SoundController : MonoBehaviour
{

    /// <summary>
    /// This is the low pitch made by the revving engine.
    /// </summary>
    public AudioSource engineLow;

    /// <summary>
    /// This is the mid pitch made by the revving engine.
    /// </summary>
    public AudioSource engineMid;

    /// <summary>
    /// This is the high pitch made by the revving engine.
    /// </summary>
    public AudioSource engineHigh;

    /// <summary>
    /// This bool controls whether or not the engine revving sound will play.
    /// </summary>
    public bool engineRevving = false;

    /// <summary>
    /// This bool tracks what sound the engine rev should play.
    /// 1: low
    /// 2: mid
    /// 3: high
    /// </summary>
    int engineStep = 1;
	
	/// <summary>
    /// This is the update loop.  If the engine is revving, it is played continuously here.
    /// </summary>
	void Update () {
        if (engineRevving)
        {
            switch (engineStep)
            {
                case 1:
                    engineLow.Play();
                    engineStep++;
                    break;
                case 2:
                    engineMid.Play();
                    engineStep++;
                    break;
                case 3:
                    engineHigh.Play();
                    engineStep = 1;
                    break;
            }
        }
	}
}
