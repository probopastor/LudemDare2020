using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackButtonsManager : Problem
{
    public GameObject hackButton;
    public Vector3[] buttonPositions;
    public GameObject computer;

    /// <summary>
    /// Stop the command prompt and begin problems
    /// </summary>
    public override void CauseProblem()
    {
        HackButtonCounter.instance.ResetHackCount();
        HackButtonCounter.instance.ActivateCounter();
        CmdPrompt.instance.ErrorActive(true);
    }

    /// <summary>
    /// If the Command Prompt is not minimized, set it to true
    /// </summary>
    public override void SolveProblem()
    {
        CmdPrompt.instance.ErrorActive(false);
    }
}
