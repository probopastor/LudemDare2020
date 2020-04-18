using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hackboi : MonoBehaviour
{
    public string[] possibleMessages;

    public TextMeshProUGUI hackerText;

    private bool isEnabled;

    public float minMessageDelay = 1f;
    public float maxMessageDelay = 10f;

    private int index = 0;
    private IEnumerator coroutine;

    private void OnEnable()
    {
        coroutine = SendMessages();
        StartCoroutine(coroutine);
    }

    private void OnDisable()
    {
        StopCoroutine(coroutine);
    }

    private IEnumerator SendMessages()
    {
        index = Random.Range(0, possibleMessages.Length);
        hackerText.text = hackerText.text + "\n" + possibleMessages[index];

        float timeBeforeNextMessage = Random.Range(minMessageDelay, maxMessageDelay);
        yield return new WaitForSeconds(timeBeforeNextMessage);

        StartCoroutine(SendMessages());
    }
}
