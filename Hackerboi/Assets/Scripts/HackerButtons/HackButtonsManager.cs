using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackButtonsManager : Problem
{
    public GameObject hackButton;
    public Vector3[] buttonPositions;
    public GameObject computer;
    public cmdMinimize minimized;

    public override void CauseProblem()
    {
        minimized = FindObjectOfType<cmdMinimize>();

        HackButtonCounter.instance.ResetHackCount();
        HackButtonCounter.instance.ActivateCounter();
        CmdPrompt.instance.SetCommandPromptRunning(false);
    }

    public override void SolveProblem()
    {
        if(!minimized.cmdAnimator.GetBool("cmdIsMinimized"))
        {
            CmdPrompt.instance.SetCommandPromptRunning(true);
        }
    }
}
