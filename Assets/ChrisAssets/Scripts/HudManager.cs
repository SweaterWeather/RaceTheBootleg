using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// This script updates the information in the UI through several static values, so that they can be easily altered from
/// anywhere in the script.
/// </summary>
public class HudManager : MonoBehaviour {

    /// <summary>
    /// This is the text field of the shield counter.
    /// </summary>
    public Text shieldText;

    /// <summary>
    /// This is the text field of the jump counter.
    /// </summary>
    public Text jumpText;

    /// <summary>
    /// This is how many jumps you currently have.
    /// </summary>
    public static int jumpCount;

    /// <summary>
    /// This is how many shields you currently have.
    /// </summary>
    public static int shieldCount;

    /// <summary>
    /// This is the maximum number of jumps you can have.
    /// </summary>
    public static int maxJump;

    /// <summary>
    /// This is the maximum number of shields you can have.
    /// </summary>
    public static int maxShield;
	
	/// <summary>
    /// This is the update loop, it updates the text fields with their proper information, if they exist.
    /// </summary>
	void Update () {
	if(jumpText)jumpText.text = "" + jumpCount + "/" + maxJump + "";
    if(shieldText)shieldText.text = "" + shieldCount + "/" + maxShield + "";
	}
}
