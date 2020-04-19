using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class TimeManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI dateText;

    private string hour;
    private string minute;
    private string day;
    private string month;
    private string year;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DateTime time = DateTime.Now;
        hour = time.Hour.ToString();
        minute = time.Minute.ToString();

        if(time.Minute < 10)
        {
            minute = "0" + time.Minute.ToString();
        }

        day = time.Day.ToString();
        month = time.Month.ToString();
        year = time.Year.ToString();

        timeText.text = hour + ":" + minute;
        dateText.text = month + "/" + day + "/" + year;
    }

    /// <summary>
    /// Gets the current system time
    /// </summary>
    /// <returns></returns>
    public string GetTime()
    {
        return hour + ":" + minute;
    }

    /// <summary>
    /// Gets the current system date
    /// </summary>
    /// <returns></returns>
    public string GetDate()
    {
        return month + "/" + day + "/" + year;
    }
}
