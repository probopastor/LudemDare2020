using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgramManager : MonoBehaviour
{
    //public GameObject commandPrompt;
    public GameObject hackerPrompt;
    //public GameObject email;

    private bool commandPromptEnabled;
    private bool hackerPromptEnabled;
    private bool emailEnabled;

    // Start is called before the first frame update
    void Start()
    {
        //commandPrompt.SetActive(false);
        hackerPrompt.SetActive(false);
        //email.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //public void EnableCommandPrompt()
    //{
    //    if (!commandPromptEnabled)
    //    {
    //        commandPromptEnabled = true;
    //        commandPrompt.SetActive(true);
    //    }
    //    else if (commandPromptEnabled)
    //    {
    //        commandPromptEnabled = false;
    //        commandPrompt.SetActive(false);
    //    }
    //}

    public void EnableHackerPrompt()
    {
        if (!hackerPromptEnabled)
        {
            hackerPromptEnabled = true;
            hackerPrompt.SetActive(true);
        }
        else if (hackerPromptEnabled)
        {
            hackerPromptEnabled = false;
            hackerPrompt.SetActive(false);
        }
    }

    //public void EnableEmail()
    //{
    //    if (!emailEnabled)
    //    {
    //        emailEnabled = true;
    //        email.SetActive(true);
    //    }
    //    else if (emailEnabled)
    //    {
    //        emailEnabled = false;
    //        email.SetActive(false);
    //    }
    //}

}
