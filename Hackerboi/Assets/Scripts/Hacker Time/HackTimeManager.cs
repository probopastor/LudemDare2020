﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackTimeManager : Problem
{
    public GameObject hackTimer;

    public override void CauseProblem()
    {
        CmdPrompt.instance.ErrorActive(true);
        Instantiate(hackTimer, transform.position, Quaternion.identity, transform);
    }

    public override void SolveProblem()
    {
        CmdPrompt.instance.ErrorActive(false);
    }
}
