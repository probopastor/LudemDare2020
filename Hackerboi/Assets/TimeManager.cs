using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class TimeManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI dateText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DateTime time = DateTime.Now;
        string hour = time.Hour.ToString();
        string minute = time.Minute.ToString();

        if(time.Minute < 10)
        {
            minute = "0" + time.Minute.ToString();
        }

        string day = time.Day.ToString();
        string month = time.Month.ToString();
        string year = time.Year.ToString();

        timeText.text = hour + ":" + minute;
        dateText.text = month + "/" + day + "/" + year;
    }
}
