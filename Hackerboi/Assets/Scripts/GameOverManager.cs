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
        if (highScoreText != null)
        {
            highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        }
        
        currentScoreText.text = ScoringManager.currentScore.ToString();

        if (highScoreText != null)
        {
            if (ScoringManager.currentScore > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", ScoringManager.currentScore);
                highScoreText.text = ScoringManager.currentScore.ToString();
                highScore = ScoringManager.currentScore;
                ScoringManager.currentScore = 0;
            }
        }

    }

}
