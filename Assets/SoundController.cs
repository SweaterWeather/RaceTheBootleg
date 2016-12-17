using UnityEngine;
using System.Collections;

/// <summary>
/// This script controls the sound effects and music of the game.
/// </summary>
public class SoundController : MonoBehaviour
{
    /// <summary>
    /// An easier to use way to call for sounds to play.
    /// </summary>
    public static bool playBoost = false;
    /// <summary>
    /// An easier to use way to call for sounds to play.
    /// </summary>
    public static bool playCombo = false;
    /// <summary>
    /// An easier to use way to call for sounds to play.
    /// </summary>
    public static bool playClick = false;
    /// <summary>
    /// An easier to use way to call for sounds to play.
    /// </summary>
    public static bool playDeath = false;
    /// <summary>
    /// An easier to use way to call for sounds to play.
    /// </summary>
    public static bool playHurt = false;
    /// <summary>
    /// An easier to use way to call for sounds to play.
    /// </summary>
    public static bool playPickup = false;
    /// <summary>
    /// An easier to use way to call for sounds to play.
    /// </summary>
    public static bool playPowerup = false;

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
    /// This is the audio for the boost.
    /// </summary>
    public AudioSource boost;

    /// <summary>
    /// This is the audio for the combo.
    /// </summary>
    public AudioSource combo;

    /// <summary>
    /// This is the audio for the click.
    /// </summary>
    public AudioSource click;

    /// <summary>
    /// This is the audio for the death.
    /// </summary>
    public AudioSource death;

    /// <summary>
    /// This is the audio for the hurt.
    /// </summary>
    public AudioSource hurt;

    /// <summary>
    /// This is the audio for the pick up.
    /// </summary>
    public AudioSource pickUp;

    /// <summary>
    /// This is the audio for the power up.
    /// </summary>
    public AudioSource powerUp;

    /// <summary>
    /// This is the audio for the menumusic.
    /// </summary>
    public AudioSource menuMusic;

    /// <summary>
    /// This is the audio for the game music.
    /// </summary>
    public AudioSource gameMusic;

    /// <summary>
    /// This is the audio for the game over music.
    /// </summary>
    public AudioSource loseMusic;

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
    /// This function plays the boost sound effect.
    /// </summary>
    public void PlayBoost()
    {
        if (boost)
        {
            boost.Play();
        }
    }

    /// <summary>
    /// This function plays the click sound effect.
    /// </summary>
    public void PlayClick()
    {
        if (click)
        {
            click.Play();
        }
    }

    /// <summary>
    /// This function plays the combo sound effect.
    /// </summary>
    public void PlayCombo()
    {
        if (combo)
        {
            combo.Play();
        }
    }

    /// <summary>
    /// This function plays the death sound effect.
    /// </summary>
    public void PlayDeath()
    {
        if (death)
        {
            death.Play();
        }
    }

    /// <summary>
    /// STOP.
    /// </summary>
    public void StopGameMusic()
    {
        if (gameMusic)
        {
            gameMusic.Stop();
        }
    }

    /// <summary>
    /// This function plays the damage sound effect.
    /// </summary>
    public void PlayDamage()
    {
        if (hurt)
        {
            hurt.Play();
        }
    }

    /// <summary>
    /// This function plays the pick up sound effect.
    /// </summary>
    public void PlayPickUp()
    {
        if (pickUp)
        {
            pickUp.Play();
        }
    }

    /// <summary>
    /// This function plays the power up sound effect.
    /// </summary>
    public void PlayPowerUp()
    {
        if (powerUp)
        {
            powerUp.Play();
        }
    }

    /// <summary>
    /// This function plays the menu music sound effect.
    /// </summary>
    public void PlayMenuMusic()
    {
        if (menuMusic)
        {
            menuMusic.Play();
        }
    }

    /// <summary>
    /// This function plays the game music sound effect.
    /// </summary>
    public void PlayGameMusic()
    {
        if (gameMusic)
        {
            gameMusic.Play();
        }
    }

    /// <summary>
    /// This function plays the game over sound effect.
    /// </summary>
    public void PlayLoseMusic()
    {
        if (loseMusic)
        {
            loseMusic.Play();
        }
    }

    /// <summary>
    /// This is the update loop.  If the engine is revving, it is played continuously here.
    /// </summary>
    void Update ()
    {

        if (playBoost)
        {
            playBoost = false;
            PlayBoost();
        }

        if (playClick)
        {
            playClick = false;
            PlayClick();
        }

        if (playCombo)
        {
            playCombo = false;
            PlayCombo();
        }

        if (playDeath)
        {
            playDeath = false;
            PlayDeath();
        }

        if (playHurt)
        {
            playHurt = false;
            PlayDamage();
        }

        if (playPickup)
        {
            playPickup = false;
            PlayPickUp();
        }

        if (playPowerup)
        {
            playPowerup = false;
            PlayPowerUp();
        }


        if (engineRevving)
        {
            switch (engineStep)
            {
                case 1:
                    if(engineLow)engineLow.Play();
                    engineStep++;
                    break;
                case 2:
                    if(engineMid)engineMid.Play();
                    engineStep++;
                    break;
                case 3:
                    if(engineHigh)engineHigh.Play();
                    engineStep = 1;
                    break;
            }
        }
	}
}
