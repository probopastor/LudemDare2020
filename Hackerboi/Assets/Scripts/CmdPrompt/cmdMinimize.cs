using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cmdMinimize : MonoBehaviour
{
    public Animator cmdAnimator;

    public Animator emailAnimator;

    /// <summary>
    /// Minimizes the Command Prompt upon clicking it's close button
    /// </summary>
    public void MinimizeCmd()
    {
        cmdAnimator.SetBool("cmdIsMinimized", true);
        cmdAnimator.SetBool("cmdIsMaximized", false);

        CmdPrompt.instance.SetCommandPromptRunning(false);
    }

    public void MinimizeEmail()
    {
        emailAnimator.SetBool("emailMinimized", true);
        emailAnimator.SetBool("emailMaximized", false);
    }
}
