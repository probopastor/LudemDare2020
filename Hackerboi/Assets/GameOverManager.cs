using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI currentScore;


    // Start is called before the first frame update
    void Start()
    {
        currentScore.text = ScoringManager.currentScore.ToString();   
    }

}
