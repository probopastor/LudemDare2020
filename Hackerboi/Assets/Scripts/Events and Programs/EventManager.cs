using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;

    public float minTimeBeforeEvent = 1f;
    public float maxTimeBeforeEvent = 60f;

    private float eventWaitTime = 0;

    public int numberOfEvents = 0;

    private int eventIndex = 0;

    private bool errorSolved;

    public Problem[] problems;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(GenerateEvent());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) //debug purposes
        {
            ProblemTime();
        }
    }

    /// <summary>
    /// Call this to generate a random error event. Make sure to add the problem to the array!
    /// </summary>
    void ProblemTime()
    {
        int index = Random.Range(0, problems.Length);

        problems[index].CauseProblem();
    }

    private IEnumerator GenerateEvent()
    {
        eventWaitTime = Random.Range(minTimeBeforeEvent, maxTimeBeforeEvent);
        yield return new WaitForSeconds(eventWaitTime);

        eventIndex = Random.Range(1, numberOfEvents + 1);
        errorSolved = false;
        StartCoroutine(GenerateEvent());
    }

    /// <summary>
    /// Gets which event index should currently be running
    /// </summary>
    /// <returns></returns>
    public int GetEventIndex()
    {
        if(!errorSolved)
        {
            return eventIndex;
        }
        else
        {
            return 0;
        }
    }

    public void SetErrorStatus(bool isSolved)
    {
        errorSolved = isSolved;
    }
}
