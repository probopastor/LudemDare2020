using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteProgramError : Problem
{
    private EmailManager emailManager;

    public override void CauseProblem()
    {
        emailManager = FindObjectOfType<EmailManager>();

        CmdPrompt.instance.ErrorActive(true);
        GameObject programEmail = emailManager.CreateProgramEmail();
    }

    public override void SolveProblem()
    {
        CmdPrompt.instance.ErrorActive(false);
    }
}
