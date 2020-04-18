using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ScoringManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int currentScore = 0;
    
    public void Start()
    {
        InvokeRepeating("IncreaseScore", 1, 1);
    }

    void IncreaseScore()
    {
        currentScore++;
        scoreText.text = "<< Score Counter ->" + currentScore.ToString();
    }





}
