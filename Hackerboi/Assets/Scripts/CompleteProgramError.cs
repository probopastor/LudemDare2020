using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteProgramError : Problem
{
    private EmailManager emailManager;
    private GameObject programEmail;
    public override void CauseProblem()
    {
        CmdPrompt.instance.ErrorActive(true);

        emailManager = FindObjectOfType<EmailManager>();
        programEmail = emailManager.CreateProgramEmail();
    }

    public override void SolveProblem()
    {
        Destroy(programEmail);
        CmdPrompt.instance.ErrorActive(false);
    }
}
