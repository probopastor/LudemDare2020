using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class CmdPrompt : MonoBehaviour
{
    #region variables

    public string[] errorMessages;
    private int errorIndex = 0;

    public TMP_InputField currentText;

    public string[] possibleMessages;
    public float minMessageDelay = 1f;
    public float maxMessageDelay = 10f;

    private int index = 0;
    private IEnumerator coroutine;
    private bool showOnceUntilEnabledInternet;


    //cmd prompt mechanics
    
    public bool cmdPromptEnabled = false;
    public Slider hackerSlider;
    
    public TextMeshProUGUI hackerText;
    public TextMeshProUGUI errorText;

    [Header("Increase Slider Values")]
    public float increaseSliderSpeed = 1;
    public float timeTillIncrease;
    public float currentTimeTillIncrease;

    [Header("Decrease Slider Values")]
    public float decreaseSliderSpeed = 1;
    public float timeTillDecrease;
    public float currentTimeTillDecrease;

    private EventManager eventManager;
    private bool errorInProgress;
    private bool cmdTextErrorClear;

    public SceneTransitionerMainGameOut outro;
    #endregion




    #region functions

    public void Start()
    {
        eventManager = FindObjectOfType<EventManager>();
        errorText.text = " ";
        cmdTextErrorClear = false;
        showOnceUntilEnabledInternet = false;
    }


    public void Update()
    {
        //if the cmdPrompt is open and assigned than run the fill slider function
        if (hackerSlider != null && cmdPromptEnabled)
        {
            if(LightController.instance.GetGameStarted())
            {
                IncreaseHackerSlider();
            }
        }

        if (hackerSlider != null && !cmdPromptEnabled)
        {
            if(LightController.instance.GetGameStarted())
            {
                DecreaseHackerSlider();
            }
        }

        if (!errorInProgress)
        {
            switch (eventManager.GetEventIndex())
            {
                case 0:
                    //
                    errorInProgress = false;
                    break;
                case 1:
                    errorInProgress = true;
                    errorIndex = 0;
                    StartCoroutine(ConfirmationError());
                    break;
                case 2:
                    errorInProgress = true;
                    errorIndex = 0;
                    StartCoroutine(ConfirmationError());
                    break;
                default:
                    break;
            }
        }

        if(LightController.instance.GetRouterStatus())
        {
            showOnceUntilEnabledInternet = false;
        }
    }


    //function that fills the hacker slidier
    public void IncreaseHackerSlider()
    {
        currentTimeTillIncrease += 1 * Time.deltaTime * increaseSliderSpeed;


        if (timeTillIncrease <= currentTimeTillIncrease)
        {
            hackerSlider.value++;
            currentTimeTillIncrease = 0;
            //print("increase bar");
        }

    }

    public void DecreaseHackerSlider()
    {

        currentTimeTillDecrease += 1 * Time.deltaTime * decreaseSliderSpeed;

        if (timeTillDecrease <= currentTimeTillDecrease)
        {
            hackerSlider.value--;
            if(hackerSlider.value <= 0)
            {
                if (outro != null)
                {
                    outro.Lose();
                }
                return;
            }
            currentTimeTillDecrease = 0;
           // print("decrease bar");
        }
    }

    //function to be called by buttons to open/close the cmdPrompt and to start/stop the hacking text
    public void cmdPromptOpen(bool enabled)
    {

        //for when this function runs to open the command prompts. Starts hacking
        if (enabled && cmdPromptEnabled == false && !errorInProgress)
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
            if(LightController.instance.GetRouterStatus())
            {
                index = Random.Range(0, possibleMessages.Length);
                hackerText.text = hackerText.text + "\n" + possibleMessages[index];

                float timeBeforeNextMessage = Random.Range(minMessageDelay, maxMessageDelay);
                yield return new WaitForSeconds(timeBeforeNextMessage);
            }
            else
            {
                if(!showOnceUntilEnabledInternet)
                {
                    showOnceUntilEnabledInternet = true;
                    hackerText.text = hackerText.text + "\n" + ">> Error: No Internet Connection";
                }
            }

            StartCoroutine(SendMessages());
        }
    }

    private IEnumerator ConfirmationError()
    {
        if (LightController.instance.GetRouterStatus())
        {
            cmdPromptEnabled = false;

            if (!cmdTextErrorClear)
            {
                hackerText.text = hackerText.text + "\n";
                cmdTextErrorClear = true;
            }

            errorText.text = errorMessages[errorIndex];

            if (currentText.text == "Yes" || currentText.text == "yes")
            {
                hackerText.text = hackerText.text + "\n" + errorMessages[errorIndex] + " >>SOLVED " + "\n" + currentText.text;
                errorText.text = " ";
                currentText.text = " ";

                errorInProgress = false;
                cmdTextErrorClear = false;
                cmdPromptEnabled = true;
                eventManager.SetErrorStatus(true);

                coroutine = SendMessages();
                StartCoroutine(coroutine);
            }
            else
            {
                yield return new WaitForSeconds(1f);
                errorText.text = " ";
                yield return new WaitForSeconds(1f);
                errorText.text = errorMessages[errorIndex];
                yield return new WaitForSeconds(1f);

                StartCoroutine(ConfirmationError());
            }

            yield return new WaitForEndOfFrame();
        }
    }

    public bool CommandPromptOpen()
    {
        return cmdPromptEnabled;
    }

    #endregion
}
