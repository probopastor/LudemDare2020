using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Email : MonoBehaviour
{
    public string subject;
    public string dateTime;
    public bool isBad;

    public GameObject subjectText;
    public GameObject dateTimeText;

    public void SetVars(string s, string dt, bool isEvil)
    {
        subject = s;
        dateTime = dt;
        isBad = isEvil;
    }

    public void SetText()
    {
        subjectText.GetComponent<TextMeshProUGUI>().text = subject;
        dateTimeText.GetComponent<TextMeshProUGUI>().text = dateTime;
    }
}
