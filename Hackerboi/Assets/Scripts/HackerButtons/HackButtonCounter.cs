using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackButtonCounter : MonoBehaviour
{
    public static HackButtonCounter instance;

    private int hackCount = 0;
    private bool isActive;

    public float timer = 5;
    private float currentTime = 0;

    public int buttonPressesToSucceed = 5;

    public GameObject[] buttonObjects;

    public HackButtonsManager hackButtonsManager;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        hackButtonsManager = FindObjectOfType<HackButtonsManager>();
        hackCount = 0;

        //Converts seconds set in timer to timeskips
        timer /= 0.02f;

        currentTime = timer;

        //Deactivate all GameObjects in buttonObjects[] to false at the start of the game
        for(int i = 0; i < buttonObjects.Length; i++)
        {
            buttonObjects[i].SetActive(false);
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //While this error is active, decrease currentTime counter.
        if(isActive)
        {
            currentTime--;

            //If the current time counter hits 0, player loses a router line
            if(currentTime <= 0)
            {
                LightController.instance.Lose();

                //Deactivate the counter, as the error is over
                DectivateCounter();
            }

            //If a set amount of buttons are pressed before the current time counter hits 0, deactivate the counter
            if (hackCount >= buttonPressesToSucceed)
            {
                DectivateCounter();
            }
        }
    }
    
    /// <summary>
    /// Activates the counter for this error
    /// </summary>
    public void ActivateCounter()
    {
        //Sets counter to true. While true, time is decreased
        isActive = true;
        hackCount = 0;
        currentTime = timer;

        //Determines buttonPressesToSucceed amount of random number of GameObjects from buttonObjects[] to enable.
        for (int i = 0; i < buttonPressesToSucceed; i++)
        {
            int randomButton = Random.Range(0, buttonObjects.Length);

            if(buttonObjects[randomButton].activeSelf)
            {
                if(randomButton == 0)
                {
                    randomButton++;
                }
                else
                {
                    randomButton--;
                }
            }

            //Enable chosen button
            buttonObjects[randomButton].SetActive(true);
        }
    }

    /// <summary>
    /// Deactivates the counter
    /// </summary>
    public void DectivateCounter()
    {
        //Sets counter to false to the counter from decreasing more time
        isActive = false;

        //Disable all buttonObjects[] gameObjects
        for (int i = 0; i < buttonObjects.Length; i++)
        {
            buttonObjects[i].SetActive(false);
        }

        hackButtonsManager.SolveProblem();
    }

    /// <summary>
    /// Resets the amount of button's pressed.
    /// </summary>
    public void ResetHackCount()
    {
        hackCount = 0;
    }

    /// <summary>
    /// Increments the amount of buttons pressed when a button is pressed during this error
    /// </summary>
    public void IncreaseHackCount()
    {
        hackCount++;
    }

    /// <summary>
    /// Returns the amount of buttons pressed this error
    /// </summary>
    /// <returns></returns>
    public int GetHackCount()
    {
        return hackCount;
    }
}
