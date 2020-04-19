using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdMaximize : MonoBehaviour
{
    public Animator cmdAnimator;
    public CmdPrompt HB;

    public Animator contactsAnimator;

    public void ClickCmdMaximize()
    {     
        cmdAnimator.SetBool("cmdIsMaximized", true);
        cmdAnimator.SetBool("cmdIsMinimized", false);
        HB.cmdPromptOpen(true);
    }

    public void ClickContactsMaximize()
    {
        contactsAnimator.SetBool("ContactsEnabled", true);
        contactsAnimator.SetBool("ContactsDisabled", false);
    }
}
