using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Email : MonoBehaviour
{
    public string subject;
    public string dateTime;
    public bool isBad;

    public void SetVars(string s, string dt, bool isEvil)
    {
        subject = s;
        dateTime = dt;
        isBad = isEvil;
    }
}
