using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteProgramError : Problem
{
    private EmailManager emailManager;
    private GameObject programEmail;

    private StarError se;
    private CoordinateManager cm;
    private string pass;

    public override void CauseProblem()
    {
        CmdPrompt.instance.ErrorActive(true);

        emailManager = FindObjectOfType<EmailManager>();
        programEmail = emailManager.CreateProgramEmail();

        if(programEmail.GetComponent<Email>().program == "Coordinate.exe")
        {
            cm = FindObjectOfType<CoordinateManager>();
            pass = cm.CreateErrorString();
        }

        else if(programEmail.GetComponent<Email>().program == "Pattern.exe")
        {
            se = FindObjectOfType<StarError>();
            pass = se.GenerateError();
        }

        CmdPrompt.instance.AddToErrorString(pass);
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
