using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEvents : MonoBehaviour
{
    public float minEventTime = 20f;
    public float maxEventTime = 39f;

    private bool generateEventsCoroutineStarted;

    private bool difficultyStage1;
    private bool difficultyStage2;
    private bool difficultyStage3;
    private bool difficultyStage4;
    private bool difficultyStage5;



    // Start is called before the first frame update
    void Start()
    {
        generateEventsCoroutineStarted = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (LightController.instance.GetGameStarted())
        {
            if (!generateEventsCoroutineStarted)
            {
                generateEventsCoroutineStarted = true;
                StartCoroutine(GenerateEvents());
            }
        }

        if(ScoringManager.currentScore > 200 && !difficultyStage1)
        {
            difficultyStage1 = true;
            minEventTime -= 4;
            maxEventTime -= 4;
        }
        else if (ScoringManager.currentScore > 500 && !difficultyStage2)
        {
            difficultyStage2 = true;
            minEventTime -= 4;
            maxEventTime -= 4;
        }
        else if (ScoringManager.currentScore > 800 && !difficultyStage3)
        {
            difficultyStage3 = true;
            maxEventTime -= 2;
            maxEventTime -= 4;
        }
        else if (ScoringManager.currentScore > 1000 && !difficultyStage4)
        {
            difficultyStage4 = true;
            minEventTime -= 2;
            maxEventTime -= 4;
        }
        else if (ScoringManager.currentScore > 1400 && !difficultyStage5)
        {
            difficultyStage5 = true;
            minEventTime -= 2;
            maxEventTime -= 4;
        }
    }

    private IEnumerator GenerateEvents()
    {
        if (LightController.instance.GetRouterStatus())
        {
            float randomTime = Random.Range(minEventTime, maxEventTime + 1);
            yield return new WaitForSeconds(randomTime);

            EventManager.instance.ProblemTime();
        }

        yield return new WaitForEndOfFrame();
        StartCoroutine(GenerateEvents());
    }
}
