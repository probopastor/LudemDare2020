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

    public GameObject contactText;
    public GameObject bodyText;

    public void SetGoodVars(string s, string dt, bool isEvil, string gr, string nr, string br)
    {
        subject = s;
        dateTime = dt;
        isBad = isEvil;
        goodRes = gr;
        neutralRes = nr;
        badRes = br;
    }

    public void SetBadVars(string s, string dt, bool isEvil)
    {
        subject = s;
        dateTime = dt;
        isBad = isEvil;
    }

    public void SetEventVars(string s, string dt, string con, string bod)
    {
        subject = s;
        dateTime = dt;
        contact = con;
        body = bod;
    }

    public void SetText()
    {
        subjectText.GetComponent<TextMeshProUGUI>().text = subject;
        dateTimeText.GetComponent<TextMeshProUGUI>().text = dateTime;

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
        dateTimeText.GetComponent<TextMeshProUGUI>().text = dateTime;
        contactText.GetComponent<TextMeshProUGUI>().text = contact;
        bodyText.GetComponent<TextMeshProUGUI>().text = body;
    }
}
