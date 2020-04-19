﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackTimeManager : Problem
{
    public GameObject hackTimer;
    public cmdMinimize minimized;

    public override void CauseProblem()
    {
        minimized = FindObjectOfType<cmdMinimize>();
        CmdPrompt.instance.SetCommandPromptRunning(false);
        Instantiate(hackTimer, transform.position, Quaternion.identity, transform);
    }

    public override void SolveProblem()
    {
        if (!minimized.cmdAnimator.GetBool("cmdIsMinimized"))
        {
            CmdPrompt.instance.SetCommandPromptRunning(true);
        }
    }
}
