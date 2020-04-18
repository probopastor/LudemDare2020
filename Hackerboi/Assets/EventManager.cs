using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public float minTimeBeforeEvent = 1f;
    public float maxTimeBeforeEvent = 60f;

    private float eventWaitTime = 0;

    public int numberOfEvents = 0;

    private int eventIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateEvent());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator GenerateEvent()
    {
        yield return new WaitForSeconds(eventWaitTime);

        eventWaitTime = Random.Range(minTimeBeforeEvent, maxTimeBeforeEvent);
        eventIndex = Random.Range(0, numberOfEvents + 1);
        StartCoroutine(GenerateEvent());
    }
}
