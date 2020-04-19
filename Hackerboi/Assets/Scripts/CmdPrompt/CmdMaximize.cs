using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdMaximize : MonoBehaviour
{
    public Animator cmdAnimator;

    public Animator contactsAnimator;

    public Animator emailAnimator;

    public bool doOnce;

    /// <summary>
    /// Maximizes the Command Prompt upon clicking it's button
    /// </summary>
    public void ClickCmdMaximize()
    {     
        cmdAnimator.SetBool("cmdIsMaximized", true);
        cmdAnimator.SetBool("cmdIsMinimized", false);

        CmdPrompt.instance.SetCommandPromptRunning(true);

        //The first time the command prompt is open, run cmdPromptOpen() on the CmdPrompt.
        if(!doOnce)
        {
            doOnce = true;
            CmdPrompt.instance.cmdPromptOpen();
        }
    }

    /// <summary>
    /// Maximizes the Contacts tab upon clicking it's button
    /// </summary>
    public void ClickContactsMaximize()
    {
        contactsAnimator.SetBool("ContactsEnabled", true);
        contactsAnimator.SetBool("ContactsDisabled", false);
    }

    public void ClickEmailMaximize()
    {
        emailAnimator.SetBool("emailMaximized", true);
        emailAnimator.SetBool("emailMinimized", false);
    }
}
