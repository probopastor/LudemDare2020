using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI highScoreText;

    public static int highScore = 0;



    // Start is called before the first frame update
    void Start()
    {
        currentScoreText.text = ScoringManager.currentScore.ToString();   

        if(ScoringManager.currentScore > highScore)
        {
            highScoreText.text = ScoringManager.currentScore.ToString();
            highScore = ScoringManager.currentScore;
            ScoringManager.currentScore = 0;
        }

    }

}
