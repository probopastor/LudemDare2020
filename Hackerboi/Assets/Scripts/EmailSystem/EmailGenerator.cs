using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailGenerator : MonoBehaviour
{
    public List<string> goodSubjects = new List<string>();
    public List<string> badSubjects = new List<string>();

    //the responses will correspond with the same index as the good subject
    public List<string> goodResponse = new List<string>();
    public List<string> neutralResponse = new List<string>();
    public List<string> badResponse = new List<string>();

    public List<string> emailEventSubjects = new List<string>();
    public List<string> programs = new List<string>();
    public List<string> contacts = new List<string>();
    public List<string> phoneyContacts = new List<string>();
    private string characters = "0123456789abcdefghijkmnopqrstuvwxABCDEFGHJKLMNOPQRSTUVWXYZ";

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
        int randContact = Random.Range(0, contacts.Count);

        TimeManager thisTime = FindObjectOfType<TimeManager>();

        GameObject g = Instantiate(emailPrefab, emailPanel.transform);
        g.GetComponent<Email>().SetGoodVars(goodSubjects[randSubject], thisTime.GetTime() + " " + thisTime.GetDate(), false, goodResponse[randSubject], neutralResponse[randSubject],
            badResponse[randSubject], contacts[randContact]);
        g.GetComponent<Email>().SetText();
        //g.GetComponent<Email>().GoodEffect();

        return g;
    }

    public GameObject GenerateBadEmails()
    {
        int randBadSubject = Random.Range(0, badSubjects.Count);
        int randBadContact = Random.Range(0, phoneyContacts.Count);

        int randGoodSubject = Random.Range(0, goodSubjects.Count);
        int randGoodContact = Random.Range(0, contacts.Count);

        int subjectToUse = Random.Range(0, goodSubjects.Count);
        string theSubject = goodSubjects[subjectToUse];

        int contactToUse = Random.Range(0, contacts.Count);
        string theContact = contacts[contactToUse];

        TimeManager thisTime = FindObjectOfType<TimeManager>();
        string phonyTime = thisTime.GetTime();
        string randomDate = thisTime.GetDate();

        int phonyInformation = Random.Range(0, 100);

        if(phonyInformation < 24)
        {
            //Determine random hour and minute for email header
            int randomHour = Random.Range(0, 24);
            int randomMinute = Random.Range(0, 60);

            int generateRandomTime = Random.Range(0, 3);

            if (generateRandomTime < 2)
            {
                //String of phony hour and minute
                phonyTime = randomHour + ":" + randomMinute;

                //Generate a random number to check for easter egg time
                int rareTimeChance = Random.Range(0, 100);

                //If rare time chance is 5 or lower, phonytime becomes easter egg time
                if (rareTimeChance <= 5)
                {
                    phonyTime = "41 O'Clock AM";
                }

                //If phony time randomly equals the real time, phony equals a fake time
                if (thisTime.GetTime() == phonyTime)
                {
                    phonyTime = "5 O'Clock";
                }
            }
        }
        else if(phonyInformation < 49)
        {
            //Determine random day, month and year for email header
            int randomMonth = Random.Range(0, 13);
            int randomDay = Random.Range(0, 36);
            int randomYear = Random.Range(2000, 2026);
            randomDate = randomMonth + "/" + randomDay + "/" + randomYear;
        }
        else if(phonyInformation < 74)
        {
            subjectToUse = randBadSubject;
            theSubject = badSubjects[subjectToUse];
        }
        else if(phonyInformation < 99)
        {
            contactToUse = randBadContact;
            theContact = phoneyContacts[contactToUse];
        }


        GameObject g = Instantiate(emailPrefab, emailPanel.transform);
        g.GetComponent<Email>().SetBadVars(theSubject, phonyTime + " " + randomDate, true, theContact);
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
            "the darkweb, try it: " + pass, pass, "not needed");
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
            "I've sent the executable to your desktop! " + "Check your error for what you have to input" , "not needed", programs[randProgram]);
        g.GetComponent<Email>().SetEventText();

        programIcons[randProgram].SetActive(true);

        return g;
    }

    public GameObject[] GetProgramIcons()
    {
        return programIcons;
    }
}

