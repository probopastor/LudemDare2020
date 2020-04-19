using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackTimeManager : Problem
{
    public GameObject hackTimer;
    public cmdMinimize minimized;

    public override void CauseProblem()
    {
        minimized = FindObjectOfType<cmdMinimize>();
        CmdPrompt.instance.ErrorActive(true);
        Instantiate(hackTimer, transform.position, Quaternion.identity, transform);
    }

    public override void SolveProblem()
    {
        CmdPrompt.instance.ErrorActive(false);
    }
}
