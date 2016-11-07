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
    /// This is the text field of the current score.
    /// </summary>
    public Text scoreText;

    /// <summary>
    /// This is text field of the current combo.
    /// </summary>
    public Text comboText;

    /// <summary>
    /// This is the text field of the current item collection rate.
    /// </summary>
    public Text itemText;

    /// <summary>
    /// This is how many jumps you currently have.
    /// </summary>
    public static int jumpCount;

    /// <summary>
    /// This is how many shields you currently have.
    /// </summary>
    public static int shieldCount;

    /// <summary>
    /// This is the player's current score.
    /// </summary>
    public static int score;

    /// <summary>
    /// This is the player's current combo.
    /// </summary>
    public static int combo;

    /// <summary>
    /// A cooldown timer to track the time between item pips ticking down after scoring.
    /// </summary>
    private float coolDown = .1f;

    /// <summary>
    /// This int tracks the ammount of pickups the player is holding.
    /// </summary>
    public static int pickupCounter;

    /// <summary>
    /// This is the maximum number of jumps you can have.
    /// </summary>
    public static int maxJump;

    /// <summary>
    /// This is the maximum number of shields you can have.
    /// </summary>
    public static int maxShield;

    /// <summary>
    /// This is the start function, it resets all values to 0.
    /// </summary>
    void Start ()
    {

    }
	
	/// <summary>
    /// This is the update loop, it updates the text fields with their proper information, if they exist.
    /// </summary>
	void Update () {
	    if (jumpText) jumpText.text = "" + jumpCount + "/" + maxJump + "";
        if (shieldText) shieldText.text = "" + shieldCount + "/" + maxShield + "";
        if (scoreText) scoreText.text = "" + score + "";
        if (comboText) comboText.text = "x" + combo + "";
        if (itemText)
        {
            //This tricky bit just updates a more precise and less literal bit of UI, and animates it toward the end.
            switch (pickupCounter)
            {
                case 0:
                    itemText.text = "ΔΔΔΔΔ";
                    break;
                case 1:
                    itemText.text = "▲ΔΔΔΔ";
                    break;
                case 2:
                    itemText.text = "▲▲ΔΔΔ";
                    break;
                case 3:
                    itemText.text = "▲▲▲ΔΔ";
                    break;
                case 4:
                    itemText.text = "▲▲▲▲Δ";
                    break;
                case 5:
                    itemText.text = "▲▲▲▲▲";
                    coolDown -= Time.deltaTime;
                    if (coolDown <= 0) pickupCounter = 6;
                    break;
                case 6:
                    itemText.text = "Δ▲▲▲▲";
                    coolDown -= Time.deltaTime;
                    if (coolDown <= 0) pickupCounter = 7;
                    break;
                case 7:
                    itemText.text = "ΔΔ▲▲▲";
                    coolDown -= Time.deltaTime;
                    if (coolDown <= 0) pickupCounter = 8;
                    break;
                case 8:
                    itemText.text = "ΔΔΔ▲▲";
                    coolDown -= Time.deltaTime;
                    if (coolDown <= 0) pickupCounter = 9;
                    break;
                case 9:
                    itemText.text = "ΔΔΔΔ▲";
                    coolDown -= Time.deltaTime;
                    if (coolDown <= 0)
                    {
                        combo++;
                        pickupCounter = 0;
                    }
                    break;
            }
        }
	}
}
