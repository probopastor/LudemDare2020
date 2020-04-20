using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class CmdPrompt : MonoBehaviour
{
    #region variables

    public static CmdPrompt instance;

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

    [Header("Increase Slider Values")]
    public float increaseSliderSpeed = 1;
    public float timeTillIncrease;
    public float currentTimeTillIncrease;

    [Header("Decrease Slider Values")]
    public float decreaseSliderSpeed = 1;
    public float timeTillDecrease;
    public float currentTimeTillDecrease;

    private EventManager eventManager;
    private bool cmdTextErrorClear;

    private bool errorActive;

    private bool passwordError;
    private string passwordToEnter;

    private bool emailProgramError;
    private GameObject managerProgramNeeded;

    public SceneTransitionerMainGameOut outro;

    private bool enterPressed;
    #endregion




    #region functions

    public void Start()
    {
        instance = this;

        eventManager = FindObjectOfType<EventManager>();
        cmdTextErrorClear = false;
        showOnceUntilEnabledInternet = false;
    }


    public void Update()
    {
        //If the Command Prompt is running, increase the hacker slider.
        if ((hackerSlider != null && cmdPromptEnabled) && !errorActive)
        {
            if(LightController.instance.GetGameStarted())
            {
                IncreaseHackerSlider();
            }
        }

        //If the command prompt is not running, decrease the hacker slider.
        if ((hackerSlider != null && !cmdPromptEnabled) || errorActive)
        {
            if(LightController.instance.GetGameStarted())
            {
                DecreaseHackerSlider();
            }
        }

        //When the router is active, disable showOnceUntilEnabledInternet to reset it. This boolean is used in SendMessages().
        if (LightController.instance.GetRouterStatus())
        {
            showOnceUntilEnabledInternet = false;
        }

        if(Input.GetKeyDown(KeyCode.Return))
        {
            enterPressed = true;
        }
    }


    /// <summary>
    /// Increases the hacker slider when the command prompt is open and running
    /// </summary>
    public void IncreaseHackerSlider()
    {
        currentTimeTillIncrease += 1 * Time.deltaTime * increaseSliderSpeed;


        if (timeTillIncrease <= currentTimeTillIncrease)
        {
            hackerSlider.value++;
            currentTimeTillIncrease = 0;
        }

    }

    /// <summary>
    /// Decreases the hacker slider when the command prompt is closed or glitched
    /// </summary>
    public void DecreaseHackerSlider()
    {

        currentTimeTillDecrease += 1 * Time.deltaTime * decreaseSliderSpeed;

        if (timeTillDecrease <= currentTimeTillDecrease)
        {
            hackerSlider.value--;
            if(hackerSlider.value <= 0)
            {
                print("bruh");
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

    /// <summary>
    /// Function is called the first time the Command Prompt is opened. Starts SendMessages() coroutine to run throughout the game
    /// </summary>
    public void cmdPromptOpen()
    {
        currentTimeTillDecrease = 0;
        coroutine = SendMessages();
        StartCoroutine(coroutine);
    }

    /// <summary>
    /// Chooses messages from possibleMessages[] to send after a period of time. 
    /// If messages cannot be sent, sends error messages instead.
    /// </summary>
    /// <returns></returns>
    private IEnumerator SendMessages()
    {

        if (cmdPromptEnabled == true && !errorActive)
        {
            if (enterPressed)
            {
                hackerText.text += "\n<color=blue>" + currentText.text + "</color>";
                currentText.text = " ";
                enterPressed = false;
            }

            //Determines if the router is on or off
            if (LightController.instance.GetRouterStatus())
            {
                //Chooses a random index from possibleMessages[] tp send as a message
                index = Random.Range(0, possibleMessages.Length);
                hackerText.text = hackerText.text + "\n" + possibleMessages[index];

                float timeBeforeNextMessage = Random.Range(minMessageDelay, maxMessageDelay);
                yield return new WaitForSeconds(timeBeforeNextMessage);
            }
            //If the router is off, display No Internet Connection error
            else
            {
                //Display this error once to prevent text spam
                if(!showOnceUntilEnabledInternet)
                {
                    showOnceUntilEnabledInternet = true;
                    hackerText.text = hackerText.text + "\n" + "<color=red>>> Error: No Internet Connection</color>";
                }
            }
        }
        //If the command prompt is not enabled, run other appropriate error messages in this else
        else if(cmdPromptEnabled == true && errorActive)
        {
            //Other error messages here. 

            /* Steps to do this: 
             * 1. Have EventManager.cs set a public Setter method on this script. 
             * For example, public void SetTestError() { testError = true;} <-- Be sure to create a testError boolean at the top of the script first that starts as false.
             * 2. Here, check if testError is true: if(testError) {  hackerText.text = hackerText.text + "\n" + ">> Error: This is a test error";}
             * 3. Depending on what the error does, be sure to prevent the Command Prompt from displaying any more messages.
             * To do this, type SetCommandPromptRunning(false); 
             * 4. When the error is solved, be sure to have it say SetCommandPromptRunning(true); so that normal Command Prompt messages can be resent
             */

            if (passwordError)
            {
                if(enterPressed)
                {
                    if (currentText.text == passwordToEnter)
                    {
                        passwordError = false;
                        SubmitPasswordError submitPasswordError = FindObjectOfType<SubmitPasswordError>();
                        submitPasswordError.SolveProblem();
                        hackerText.text += "\n<color=blue>" + currentText.text + "</color>";
                        currentText.text = " ";
                        hackerText.text += "\n<color=green>" + ">>PASSWORD CORRECT" + "</color>";
                    }
                    else if (currentText.text != passwordToEnter)
                    {
                        hackerText.text += "\n<color=blue>" + currentText.text + "</color>";
                        currentText.text = " ";
                        hackerText.text += "\n<color=red>" + ">>PASSWORD INCORRECT" + "</color>";
                    }
                    enterPressed = false;
                }
            }

            if (emailProgramError)
            {

            }
        }

        yield return new WaitForEndOfFrame();
        StartCoroutine(SendMessages());
    }

    public void SendError(int index)
    {
        string errorString = errorMessages[index];
        hackerText.text += "\n<color=red>" + errorString + "</color>";
    }

    public void AddToErrorString(string addition)
    {
        hackerText.text += "\n<color=red>" + addition + "</color>";
    }

    //THIS IS OLD I WANT TO REFERENCE THE CODE HERE, PLEASE SAVE:
    //private IEnumerator ConfirmationError()
    //{
    //    if (LightController.instance.GetRouterStatus())
    //    {
    //        cmdPromptEnabled = false;

    //        if (!cmdTextErrorClear)
    //        {
    //            hackerText.text = hackerText.text + "\n";
    //            cmdTextErrorClear = true;
    //        }

    //        errorText.text = errorMessages[errorIndex];

    //        if (currentText.text == "Yes" || currentText.text == "yes")
    //        {
    //            hackerText.text = hackerText.text + "\n" + errorMessages[errorIndex] + " >>SOLVED " + "\n" + currentText.text;
    //            errorText.text = " ";
    //            currentText.text = " ";

    //            errorInProgress = false;
    //            cmdTextErrorClear = false;
    //            cmdPromptEnabled = true;
    //            eventManager.SetErrorStatus(true);

    //            yield return new WaitForEndOfFrame();
    //            //coroutine = SendMessages();
    //            //StartCoroutine(coroutine);
    //            SetCommandPromptRunning(true);

    //        }
    //        else
    //        {
    //            yield return new WaitForSeconds(1f);
    //            errorText.text = " ";
    //            yield return new WaitForSeconds(1f);
    //            errorText.text = errorMessages[errorIndex];
    //            yield return new WaitForSeconds(1f);

    //            SetCommandPromptRunning(false);
    //            StartCoroutine(ConfirmationError());
    //        }

    //        yield return new WaitForEndOfFrame();
    //    }
    //}

    /// <summary>
    /// Checks if the command prompt can be run properly
    /// </summary>
    /// <returns></returns>
    public bool CommandPromptOpen()
    {
        return cmdPromptEnabled;
    }

    /// <summary>
    /// Sets the state of the command prompt when opened or closed. If true is passed in, Command Prompt will send its regular messages. 
    /// If false, the Command Prompt will not run until true is passed in.
    /// </summary>
    /// <param name="isRunning"></param>
    public void SetCommandPromptRunning(bool isRunning)
    {
        cmdPromptEnabled = isRunning;
    }

    /// <summary>
    /// Sets the state of the command prompt from active errors. If true is passed in, Command Prompt will send its regular messages. 
    /// If false, the Command Prompt will not run until true is passed in.
    /// </summary>
    /// <param name="errorRunning"></param>
    public void ErrorActive(bool errorRunning)
    {
        errorActive = errorRunning;
    }

    /// <summary>
    /// Returns true if an error is active, false if there are no errors.
    /// </summary>
    /// <returns></returns>
    public bool GetErrorActive()
    {
        return errorActive;
    }

    public void SetPasswordError(string password)
    {
        passwordToEnter = password;
        passwordError = true;
    }

    public void SetProgramError(string programName)
    {
        emailProgramError = true;
        //the name used in the email will be the tag for the programs manager to create it
        managerProgramNeeded = GameObject.FindGameObjectWithTag(programName);
        //managerProgramNeeded
    }

    #endregion
}
