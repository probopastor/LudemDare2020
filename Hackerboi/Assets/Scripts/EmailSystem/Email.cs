using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Email : MonoBehaviour
{
    public string subject;
    public string dateTime;
    public bool isBad;

    public string goodRes;
    public string neutralRes;
    public string badRes;

    public GameObject subjectText;
    public GameObject dateTimeText;

    public GameObject res1;
    public GameObject res2;
    public GameObject res3;

    public string contact;
    public string body;
    public string pass;
    public string program;

    public GameObject contactText;
    public GameObject bodyText;

    public TimeManager tm;

    public void Awake()
    {
        if (tm == null)
        {
            tm = FindObjectOfType<TimeManager>();
        }
    }

    public void SetGoodVars(string s, string dt, bool isEvil, string gr, string nr, string br, string con)
    {
        subject = s;
        dateTime = dt;
        isBad = isEvil;
        goodRes = gr;
        neutralRes = nr;
        badRes = br;
        contact = con;
    }

    public void SetBadVars(string s, string dt, bool isEvil, string con)
    {
        subject = s;
        dateTime = dt;
        isBad = isEvil;
        contact = con;
    }

    public void SetEventVars(string s, string dt, string con, string bod, string pa, string prog)
    {
        subject = s;
        dateTime = dt;
        contact = con;
        body = bod;
        pass = pa;
        program = prog;
    }

    public void SetText()
    {
        subjectText.GetComponent<TextMeshProUGUI>().text = subject;
        dateTimeText.GetComponent<TextMeshProUGUI>().text = dateTime; //if it is bad set to the listed times
        contactText.GetComponent<TextMeshProUGUI>().text = "From: " + contact;

        if(isBad == false)
        {
            int rand = Random.Range(1, 4);
            int prevRand = rand;

            switch(rand)
            {
                case 1:
                    res1.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = goodRes;
                    res1.GetComponent<ResponseBehaviour>().type = 1;
                    break;

                case 2:
                    res2.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = goodRes;
                    res2.GetComponent<ResponseBehaviour>().type = 1;
                    break;

                case 3:
                    res3.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = goodRes;
                    res3.GetComponent<ResponseBehaviour>().type = 1;
                    break;
            }

            do
            {
                rand = Random.Range(1, 4); //choose another random
            } while (rand == prevRand);

            switch (rand)
            {
                case 1:
                    res1.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = neutralRes;
                    res1.GetComponent<ResponseBehaviour>().type = 2;
                    break;

                case 2:
                    res2.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = neutralRes;
                    res2.GetComponent<ResponseBehaviour>().type = 2;
                    break;

                case 3:
                    res3.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = neutralRes;
                    res3.GetComponent<ResponseBehaviour>().type = 2;
                    break;
            }

            if((rand == 1 || rand == 2) && (prevRand == 1 || prevRand == 2))
            {
                res3.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = badRes;
                res3.GetComponent<ResponseBehaviour>().type = 3;
            }

            if ((rand == 1 || rand == 3) && (prevRand == 1 || prevRand == 3))
            {
                res2.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = badRes;
                res2.GetComponent<ResponseBehaviour>().type = 3;
            }

            if ((rand == 2 || rand == 3) && (prevRand == 2 || prevRand == 3))
            {
                res1.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = badRes;
                res1.GetComponent<ResponseBehaviour>().type = 3;
            }
        }
    }

    public void SetEventText()
    {
        subjectText.GetComponent<TextMeshProUGUI>().text = subject;
        dateTimeText.GetComponent<TextMeshProUGUI>().text = tm.GetTime() + tm.GetDate();
        contactText.GetComponent<TextMeshProUGUI>().text = "From: " + contact;
        bodyText.GetComponent<TextMeshProUGUI>().text = body;
    }

    public void SetDateTime()
    {
        dateTimeText.GetComponent<TextMeshProUGUI>().text = tm.GetTime() + tm.GetDate(); //if it is good use time on computer
    }

    public void BadEffect()
    {
        AdManager ads = FindObjectOfType<AdManager>();

        int randomEffect = Random.Range(0, 8);

        if(randomEffect == 0)
        {
            ads.SpawnAds();
        }
        else if(randomEffect == 2)
        {
            ads.HenkAdSpam();
        }
        else if (randomEffect == 3)
        {
            ads.BigEarsAdSpam();
        }
        else if (randomEffect == 4)
        {
            ads.NeedAFixSpam();
        }
        else if (randomEffect == 5)
        {
            ads.SpearAdSpam();
        }
        else if (randomEffect == 6)
        {
            ads.BlindsAdSpam();
        }
        else if (randomEffect == 7)
        {
            ads.RaveAdSpam();
        }
    }

    public void GoodEffect()
    {
        //TODO
        Debug.Log(ScoringManager.currentScore);
        ScoringManager.currentScore += 25;
        Debug.Log(ScoringManager.currentScore);
        FindObjectOfType<ScoringManager>().scoreText.text = "Hacker Score: " + ScoringManager.currentScore.ToString();
    }
}
