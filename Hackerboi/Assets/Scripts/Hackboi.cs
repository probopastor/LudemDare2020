using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hackboi : MonoBehaviour
{
    #region variables

    public string[] possibleMessages;
    public float minMessageDelay = 1f;
    public float maxMessageDelay = 10f;

    private int index = 0;
    private IEnumerator coroutine;


    //cmd prompt mechanics
    
    public bool cmdPromptEnabled = false;
    public Slider hackerSlider;
    
    public TextMeshProUGUI hackerText;

    [Header("Increase Slider Values")]
    public float increaseSliderSpeed = 1;
    public float timeTillIncrease;
    public float currentTimeTillIncrease;

    [Header("Decrease Slider Values")]
    public float decreaseSliderSpeed = 1;
    public float timeTillDecrease;
    public float currentTimeTillDecrease;

    #endregion




    #region functions


    
    public void Update()
    {
        //if the cmdPrompt is open and assigned than run the fill slider function
        if (hackerSlider != null && cmdPromptEnabled)
        {
            IncreaseHackerSlider();
        }

        if(hackerSlider != null && cmdPromptEnabled == false)
        {
            DecreaseHackerSlider();
        }
    }


    //function that fills the hacker slidier
    public void IncreaseHackerSlider()
    {
        currentTimeTillIncrease += 1 * Time.deltaTime * increaseSliderSpeed;

        if(timeTillIncrease <= currentTimeTillIncrease)
        { 
            hackerSlider.value++;
            currentTimeTillIncrease = 0;
            print("increase bar");
        }
    }

    public void DecreaseHackerSlider()
    {

        currentTimeTillDecrease += 1 * Time.deltaTime * decreaseSliderSpeed;

        if (timeTillDecrease <= currentTimeTillDecrease)
        {
            hackerSlider.value--;
            currentTimeTillDecrease = 0;
            print("decrease bar");
        }
    }

    //don't think this actually does anything
    private void OnDisable()
    {
        StopCoroutine(coroutine);
        cmdPromptEnabled = false;
    }

    //function to be called by buttons to open/close the cmdPrompt and to start/stop the hacking text
    public void cmdPromptOpen(bool enabled)
    {

        //for when this function runs to open the command prompts. Starts hacking
        if (enabled && cmdPromptEnabled == false)
        {
            currentTimeTillDecrease = 0;
            cmdPromptEnabled = true;
            coroutine = SendMessages();
            StartCoroutine(coroutine);     
        }

        //for when this function runs to close the command prompt. Stops the hacking
        else if(!enabled &&cmdPromptEnabled == true)
        {
            currentTimeTillIncrease = 0;
            cmdPromptEnabled = false;
            StopCoroutine(coroutine);
        }
    }

    //picks a random message from a list and displays it one line down from the previous text and then runs again at a random time range
    private IEnumerator SendMessages()
    {
        if (cmdPromptEnabled == true)
        {
            index = Random.Range(0, possibleMessages.Length);
            hackerText.text = hackerText.text + "\n" + possibleMessages[index];

            float timeBeforeNextMessage = Random.Range(minMessageDelay, maxMessageDelay);
            yield return new WaitForSeconds(timeBeforeNextMessage);

            StartCoroutine(SendMessages());
        }
    }

    #endregion
}
