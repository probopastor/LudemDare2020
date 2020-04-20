using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComprimisedManager : MonoBehaviour
{
    public float minComprimiseTime = 10f;
    public float maxComprimiseTime = 70f;
    private bool comprimiseCoroutineStarted;

    private bool difficultyStage1;
    private bool difficultyStage2;
    private bool difficultyStage3;
    private bool difficultyStage4;
    private bool difficultyStage5;

    private void LateUpdate()
    {
        if (LightController.instance.GetGameStarted())
        {
            if (!comprimiseCoroutineStarted)
            {
                comprimiseCoroutineStarted = true;
                StartCoroutine(ComprimiseRouter());
            }
        }

        if (ScoringManager.currentScore > 200 && !difficultyStage1)
        {
            difficultyStage1 = true;
            maxComprimiseTime -= 5;
        }
        else if (ScoringManager.currentScore > 500 && !difficultyStage2)
        {
            difficultyStage2 = true;
            maxComprimiseTime -= 5;
        }
        else if (ScoringManager.currentScore > 800 && !difficultyStage3)
        {
            difficultyStage3 = true;
            maxComprimiseTime -= 5;
        }
        else if (ScoringManager.currentScore > 1000 && !difficultyStage4)
        {
            difficultyStage4 = true;
            minComprimiseTime -= 2;
            maxComprimiseTime -= 5;
        }
        else if (ScoringManager.currentScore > 1400 && !difficultyStage5)
        {
            difficultyStage5 = true;
            minComprimiseTime -= 2;
            maxComprimiseTime -= 5;
        }
    }

    private IEnumerator ComprimiseRouter()
    {
        if(LightController.instance.GetRouterStatus())
        {
            float randomTime = Random.Range(minComprimiseTime, maxComprimiseTime + 1);

            yield return new WaitForSeconds(randomTime);

            if (!LightController.instance.LineLost(0) && !LightController.instance.LineComprimised(0))
            {
                LightController.instance.Compromise(0);
            }
            else if (!LightController.instance.LineLost(2) && !LightController.instance.LineComprimised(2))
            {
                LightController.instance.Compromise(2);
            }
            else if (!LightController.instance.LineLost(1) && !LightController.instance.LineComprimised(1))
            {
                LightController.instance.Compromise(1);
            }
        }

        yield return new WaitForEndOfFrame();
        StartCoroutine(ComprimiseRouter());
    }
}
