using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEvents : MonoBehaviour
{
    public float minEventTime = 20f;
    public float maxEventTime = 39f;

    private bool generateEventsCoroutineStarted;

    // Start is called before the first frame update
    void Start()
    {
        generateEventsCoroutineStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (LightController.instance.GetGameStarted())
        {
            if (!generateEventsCoroutineStarted)
            {
                generateEventsCoroutineStarted = true;
                StartCoroutine(GenerateEvents());
            }
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
