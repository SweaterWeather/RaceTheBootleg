using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

/// <summary>
/// This script controls the game over state of the game.
/// </summary>
public class GameOverController : MonoBehaviour {

    /// <summary>
    /// This button switches you back to the main menu.  Or restarts the game.  Which ever idk.
    /// </summary>
    public Button button;

    /// <summary>
    /// 
    /// </summary>
    public EventSystem eventSyst;

	/// <summary>
    /// This is the startup function for the game over menu, it sets the button as the current one selected.
    /// </summary>
	void Start () {
        eventSyst = EventSystem.current;
        eventSyst.SetSelectedGameObject(button.gameObject);
	}
	
	/// <summary>
    /// This function switches you to the scene you are supposed to be in, whichever we decide that may be.
    /// </summary>
	public void SwaptoGameOver () {
        print("swapped!");
	}
}
