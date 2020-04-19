using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdMaximize : MonoBehaviour
{
    public Animator cmdAnimator;

    public Animator contactsAnimator;

    public bool doOnce;

    public void ClickCmdMaximize()
    {     
        cmdAnimator.SetBool("cmdIsMaximized", true);
        cmdAnimator.SetBool("cmdIsMinimized", false);

        CmdPrompt.instance.SetCommandPromptRunning(true);
        if(!doOnce)
        {
            doOnce = true;
            CmdPrompt.instance.cmdPromptOpen();
        }
    }

    public void ClickContactsMaximize()
    {
        contactsAnimator.SetBool("ContactsEnabled", true);
        contactsAnimator.SetBool("ContactsDisabled", false);
    }
}
