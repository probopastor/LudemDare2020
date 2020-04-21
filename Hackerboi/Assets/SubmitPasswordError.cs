using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmitPasswordError : Problem
{
    private EmailManager emailManager;
    private GameObject passwordEmail;

    public override void CauseProblem()
    {
        emailManager = FindObjectOfType<EmailManager>();

        CmdPrompt.instance.ErrorActive(true);
        passwordEmail = emailManager.CreatePasswordEmail();
        CmdPrompt.instance.SetPasswordError(passwordEmail.GetComponent<Email>().pass);
    }

    public override void SolveProblem()
    {
        CmdPrompt.instance.ErrorActive(false);
        Destroy(passwordEmail);
    }
}
