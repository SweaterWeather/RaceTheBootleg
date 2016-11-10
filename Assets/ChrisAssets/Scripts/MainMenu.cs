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
    }

	/// <summary>
    /// 
    /// </summary>
	public void PressStart () {
        swingTime.SetBool("zooming", true);
        eventSyst.SetSelectedGameObject(startEasy.gameObject);
        pressedStart.enabled = false;
    }

    // Update is called once per frame
    public void PressEasy()
    {
        print("started easy!");
    }

    // Update is called once per frame
    public void PressMid()
    {
        print("started mid!");
    }

    // Update is called once per frame
    public void PressHard()
    {
        print("started hard!");
    }
}
