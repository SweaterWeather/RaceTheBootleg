using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// This script updates the information in the UI through several static values, so that they can be easily altered from
/// anywhere in the script.
/// </summary>
public class HudManager : MonoBehaviour {

    /// <summary>
    /// Game over man.
    /// </summary>
    public GameOverController gameOver;

    /// <summary>
    /// Sound.
    /// </summary>
    public SoundController sound;

    /// <summary>
    /// A static reference to itself.
    /// </summary>
    static HudManager hudMan;

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
    public static float score;

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
    /// This is the in-game text slideout bit.
    /// </summary>
    public Animator ingameTextField;

    /// <summary>
    /// The text in the textfield.
    /// </summary>
    public Text textFieldText;

    /// <summary>
    /// This is the start function, it resets all values to 0.
    /// </summary>
    void Start ()
    {
        combo = 2;
        hudMan = this;
        score = 0;
        shieldCount = 0;
        jumpCount = 0;
        sound.PlayGameMusic();
    }

    /// <summary>
    /// This function updates the hud and score every time you pick up a blue pickup for comboing.
    /// </summary>
    public static void PickUpCombo()
    {
        pickupCounter++;
        score += combo * 100;
    }

    /// <summary>
    /// This function raises the text field to tell the player that the sun is rising.
    /// </summary>
    public void TextSunIsRising()
    {
        textFieldText.text = "Daylight Extended!";
        ingameTextField.SetTrigger("goOut");
    }

    /// <summary>
    /// This function raises the text field to tell the player how to jump.
    /// </summary>
    public void TextJumpTutorial()
    {
        textFieldText.text = "[Action] Activate Jump";
        ingameTextField.SetTrigger("goOut");
    }

    /// <summary>
    /// This function raises the text field to tell the player how to jump.
    /// </summary>
    public void TextSunlightDepleted()
    {
        textFieldText.text = "[Solar Energy Depleted!]";
        ingameTextField.SetTrigger("goOut");
    }

    /// <summary>
    /// This games the overs.
    /// </summary>
    public void GameOverMan()
    {
        sound.PlayLoseMusic();
        sound.StopGameMusic();
        Destroy(this.gameObject);
        Instantiate(gameOver);
    }

    /// <summary>
    /// This is the update loop, it updates the text fields with their proper information, if they exist.
    /// </summary>
    void Update () {
	    if (jumpText) jumpText.text = "" + jumpCount + "/" + maxJump + "";
        if (shieldText) shieldText.text = "" + shieldCount + "/" + maxShield + "";
        if (scoreText) scoreText.text = "" + (int)score + "";
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
                    if (coolDown <= 0) {
                        SoundController.playPowerup = true;
                        coolDown = .1f;
                        pickupCounter = 6;
                    }
                    break;
                case 6:
                    itemText.text = "Δ▲▲▲▲";
                    coolDown -= Time.deltaTime;
                    if (coolDown <= 0)
                    {
                        coolDown = .1f;
                        pickupCounter = 7;
                    }
                    break;
                case 7:
                    itemText.text = "ΔΔ▲▲▲";
                    coolDown -= Time.deltaTime;
                    if (coolDown <= 0)
                    {
                        coolDown = .1f;
                        pickupCounter = 8;
                    }
                    break;
                case 8:
                    itemText.text = "ΔΔΔ▲▲";
                    coolDown -= Time.deltaTime;
                    if (coolDown <= 0)
                    {
                        coolDown = .1f;
                        pickupCounter = 9;
                    }
                    break;
                case 9:
                    itemText.text = "ΔΔΔΔ▲";
                    coolDown -= Time.deltaTime;
                    if (coolDown <= 0)
                    {
                        coolDown = .1f;
                        combo++;
                        pickupCounter = 0;
                    }
                    break;
            }
        }
	}
}
