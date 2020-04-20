using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailGenerator : MonoBehaviour
{
    public List<string> goodSubjects = new List<string>();
    public List<string> badSubjects = new List<string>();
    public List<string> goodDateTime = new List<string>();
    public List<string> badDateTime = new List<string>();

    //the responses will correspond with the same index as the good subject
    public List<string> goodResponse = new List<string>();
    public List<string> neutralResponse = new List<string>();
    public List<string> badResponse = new List<string>();

    public List<string> emailEventSubjects = new List<string>();
    public List<string> programs = new List<string>();
    public List<string> contacts = new List<string>();
    private string characters = "0123456789abcdefghijklmnopqrstuvwxABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public GameObject emailPrefab;
    public GameObject emailPanel;

    public GameObject eventEmailPrefab;

    public GameObject[] programIcons;

    private void Start()
    {
        for(int i = 0; i < programIcons.Length; i++)
        {
            programIcons[i].SetActive(false);
        }
    }

    public GameObject GenerateGoodEmails()
    {
        int randSubject = Random.Range(0, goodSubjects.Count);
        int randDateTime = Random.Range(0, goodDateTime.Count);

        GameObject g = Instantiate(emailPrefab, emailPanel.transform);
        g.GetComponent<Email>().SetGoodVars(goodSubjects[randSubject], goodDateTime[randDateTime], false, goodResponse[randSubject], neutralResponse[randSubject], badResponse[randSubject]);
        g.GetComponent<Email>().SetText();

        return g;
    }

    public GameObject GenerateBadEmails()
    {
        int randSubject = Random.Range(0, badSubjects.Count);
        int randDateTime = Random.Range(0, badDateTime.Count);

        GameObject g = Instantiate(emailPrefab, emailPanel.transform);
        g.GetComponent<Email>().SetBadVars(badSubjects[randSubject], badDateTime[randDateTime], true);
        g.GetComponent<Email>().SetText();

        return g;
    }

    public string CreatePass()
    {
        string pass = "";

        for (int i = 0; i < 5; i++)
        {
            int a = Random.Range(0, characters.Length);
            pass += characters[a];
        }

        return pass;
    }

    public GameObject GeneratePasswordEmail()
    {
        int randContact = Random.Range(0, contacts.Count);

        TimeManager thisTime = FindObjectOfType<TimeManager>();

        string pass = CreatePass();

        GameObject g = Instantiate(eventEmailPrefab, emailPanel.transform);
        g.GetComponent<Email>().SetEventVars(emailEventSubjects[0] + " the hak0r ", thisTime.GetTime() + " " + thisTime.GetDate(), contacts[randContact], "im on your side ~ i found this pswd on" +
            "the darkweb, try it: " + pass, pass);
        g.GetComponent<Email>().SetEventText();

        return g;
    }

    public GameObject GenerateProgramEmail()
    {
        int randContact = Random.Range(0, contacts.Count);
        int randProgram = Random.Range(0, programs.Count);

        TimeManager thisTime = FindObjectOfType<TimeManager>();

        GameObject g = Instantiate(eventEmailPrefab, emailPanel.transform);
        g.GetComponent<Email>().SetEventVars(emailEventSubjects[1], thisTime.GetTime() + " " + thisTime.GetDate(), contacts[randContact], "I cracked the code! Use " + programs[randProgram] + " to continue your hack! " +
            "I've sent the executable to your desktop! ", "not needed");
        g.GetComponent<Email>().SetEventText();

        programIcons[randProgram].SetActive(true);

        return g;
    }

    public GameObject[] GetProgramIcons()
    {
        return programIcons;
    }
}

