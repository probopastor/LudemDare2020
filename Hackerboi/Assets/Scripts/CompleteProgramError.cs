using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteProgramError : Problem
{
    private EmailManager emailManager;

    public override void CauseProblem()
    {
        CmdPrompt.instance.ErrorActive(true);

        emailManager = FindObjectOfType<EmailManager>();
        GameObject programEmail = emailManager.CreateProgramEmail();
    }

    public override void SolveProblem()
    {
        CmdPrompt.instance.ErrorActive(false);
    }
}
