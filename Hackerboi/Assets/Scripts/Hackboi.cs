using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hackboi : MonoBehaviour
{
    public string[] possibleMessages;

    public float minMessageDelay = 1f;
    public float maxMessageDelay = 10f;

    private int index = 0;
    private IEnumerator coroutine;


    //cmd prompt mechanics
    
    public bool cmdPromptEnabled = false;
    public Slider hackerSlider;
    public float sliderSpeed = 1;
    public TextMeshProUGUI hackerText;


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
            cmdPromptEnabled = true;
            coroutine = SendMessages();
            StartCoroutine(coroutine);     
        }

        //for when this function runs to close the command prompt. Stops the hacking
        else if(!enabled &&cmdPromptEnabled == true)
        {
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

    //if the cmdPrompt is open than fill the hacker slider
    public void Update()
    {
        if(hackerSlider != null && cmdPromptEnabled)
        {
            hackerSlider.value += 1 * Time.deltaTime * sliderSpeed;
        }
    }
}
