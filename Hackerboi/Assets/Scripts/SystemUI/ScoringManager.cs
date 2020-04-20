using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ScoringManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static int currentScore = 0;
    
    public void Start()
    {
        currentScore = 0;
        InvokeRepeating("IncreaseScore", 1, 1);
    }

    /// <summary>
    /// If the command prompt is open, the game has started, and the router is on, increase the hacker score
    /// </summary>
    void IncreaseScore()
    {
        if(CmdPrompt.instance.CommandPromptOpen() && !CmdPrompt.instance.GetErrorActive() && LightController.instance.GetRouterStatus() && LightController.instance.GetGameStarted())
        {
            currentScore++;
            scoreText.text = "Hacker Score: " + currentScore.ToString();
        }
    }
}
