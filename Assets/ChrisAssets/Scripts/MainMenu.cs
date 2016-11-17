using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

/// <summary>
/// This script is the primary controller for the main menu.  It has various functions that trigger in unison with the button presses.
/// </summary>
public class MainMenu : MonoBehaviour {

    /// <summary>
    /// This is the camera of the scene.
    /// </summary>
    public Camera cam;

    /// <summary>
    /// This animator is the one that makes the camera swing from one menu to the next.
    /// </summary>
    public Animator swingTime;

    /// <summary>
    /// This is the rotation of the main menu's ring.
    /// </summary>
    public Animator rotation;

    /// <summary>
    /// The event system this part of the UI is currently running off of.
    /// </summary>
    public EventSystem eventSyst;

    /// <summary>
    /// This button represents the button on the very first start menu.
    /// </summary>
    public Button pressedStart;

    /// <summary>
    /// This button represents the easy button on the main menu.
    /// </summary>
    public Button startEasy;

    /// <summary>
    /// This button represents the medium button on the main menu.
    /// </summary>
    public Button startMid;

    /// <summary>
    /// This button represents the hard button on the main menu.
    /// </summary>
    public Button startHard;

    /// <summary>
    /// This bool tracks whether or not the camera is doing a weird fish eye thing.
    /// </summary>
    bool distorting = false;

    /// <summary>
    /// This int represents the difficulty the player has selected to start at.
    /// </summary>
    int selectedDiff = 0;

    /// <summary>
    /// 
    /// </summary>
    void Update()
    {
        if(eventSyst.currentSelectedGameObject == startEasy.gameObject)
        {
            rotation.SetInteger("index", 1);
        }
        else if(eventSyst.currentSelectedGameObject == startMid.gameObject)
        {
            rotation.SetInteger("index", 2);
        }
        else if(eventSyst.currentSelectedGameObject == startHard.gameObject)
        {
            rotation.SetInteger("index", 3);
        }

        if (distorting)
        {
            cam.fieldOfView += Time.deltaTime * 100;
            if(cam.fieldOfView >= 160)
            {
                switch (selectedDiff)
                {
                    case 1:
                        StartTheGame.startDiff = 0;
                        SceneManager.LoadScene(1);
                        break;
                    case 2:
                        StartTheGame.startDiff = 1;
                        SceneManager.LoadScene(1);
                        break;
                    case 3:
                        StartTheGame.startDiff = 2;
                        SceneManager.LoadScene(1);
                        break;
                }
            }
        }
    }

	/// <summary>
    /// 
    /// </summary>
	public void PressStart () {
        swingTime.SetBool("zooming", true);
        eventSyst.SetSelectedGameObject(startEasy.gameObject);
        pressedStart.enabled = false;
    }

    /// <summary>
    /// This function is called by a button press in game, and triggers the game to start switching to easy difficulty.
    /// </summary>
    public void PressEasy()
    {
        distorting = true;
        selectedDiff = 1;
    }

    /// <summary>
    /// This function is called by a button press in game, and triggers the game to start switching to medium difficulty.
    /// </summary>
    public void PressMid()
    {
        distorting = true;
        selectedDiff = 2;
    }

    /// <summary>
    /// This function is called by a button press in game, and triggers the game to start switching to hard difficulty.
    /// </summary>
    public void PressHard()
    {
        distorting = true;
        selectedDiff = 3;
    }
}
