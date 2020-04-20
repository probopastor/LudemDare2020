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
        GameObject[] icons = emailManager.GetEmailGenerator().GetProgramIcons();

        for(int i = 0; i < icons.Length; i++)
        {
            icons[i].SetActive(false);
        }

        emailManager.EmailNotificationOff();
        Destroy(programEmail);
        CmdPrompt.instance.ErrorActive(false);
    }
}
