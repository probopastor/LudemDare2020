using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComprimisedManager : MonoBehaviour
{
    public float minComprimiseTime = 10f;
    public float maxComprimiseTime = 70f;
    private bool comprimiseCoroutineStarted;

    private void Update()
    {
        if(LightController.instance.GetGameStarted())
        {
            if(!comprimiseCoroutineStarted)
            {
                comprimiseCoroutineStarted = true;
                StartCoroutine(ComprimiseRouter());
            }
        }
    }

    private IEnumerator ComprimiseRouter()
    {
        float randomTime = Random.Range(minComprimiseTime, maxComprimiseTime + 1);

        yield return new WaitForSeconds(randomTime);

        if(!LightController.instance.LineLost(0))
        {
            LightController.instance.Compromise(0);
        }
        else if(!LightController.instance.LineLost(3))
        {
            LightController.instance.Compromise(3);
        }
        else if (!LightController.instance.LineLost(2))
        {
            LightController.instance.Compromise(2);
        }

        StartCoroutine(ComprimiseRouter());
    }
}
