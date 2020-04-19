﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ScoringManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static int currentScore = 0;

    private CmdPrompt cmdPrompt;
    
    public void Start()
    {
        cmdPrompt = FindObjectOfType<CmdPrompt>();
        InvokeRepeating("IncreaseScore", 1, 1);
    }

    void IncreaseScore()
    {
        if(cmdPrompt.CommandPromptOpen() && LightController.instance.GetGameStarted())
        {
            currentScore++;
            scoreText.text = "Hacker Score: " + currentScore.ToString();
        }
    }
}
