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


    //cmd prompt mechanics
    public bool cmdPromptEnabled = false;
    public Slider hackerSlider;
    public float sliderSpeed = 1;

    private void OnDisable()
    {
        StopCoroutine(coroutine);
        cmdPromptEnabled = false;
    }

    public void cmdPromptOpen(bool enabled)
    {
        if (enabled)
        {
            coroutine = SendMessages();
            StartCoroutine(coroutine);
            cmdPromptEnabled = true;
        }
        else
        {
            StopCoroutine(coroutine);
            cmdPromptEnabled = false;
        }
    }


    private IEnumerator SendMessages()
    {
        index = Random.Range(0, possibleMessages.Length);
        hackerText.text = hackerText.text + "\n" + possibleMessages[index];

        float timeBeforeNextMessage = Random.Range(minMessageDelay, maxMessageDelay);
        yield return new WaitForSeconds(timeBeforeNextMessage);

        StartCoroutine(SendMessages());
    }

    public void Update()
    {
        if(hackerSlider != null && cmdPromptEnabled)
        {
            hackerSlider.value += 1 * Time.deltaTime * sliderSpeed;
        }
    }
}
