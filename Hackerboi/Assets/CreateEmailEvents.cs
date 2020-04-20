using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEmailEvents : MonoBehaviour
{
    public float minEmailTime = 15f;
    public float maxEmailTime = 35f;

    private bool generateEmailsCoroutineStarted;
    private EmailManager emailManager;

    // Start is called before the first frame update
    void Start()
    {
        emailManager = FindObjectOfType<EmailManager>();
        generateEmailsCoroutineStarted = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (LightController.instance.GetGameStarted())
        {
            if (!generateEmailsCoroutineStarted)
            {
                generateEmailsCoroutineStarted = true;
                StartCoroutine(GenerateEmails());
            }
        }
    }

    private IEnumerator GenerateEmails()
    {
        if (LightController.instance.GetRouterStatus())
        {
            float randomTime = Random.Range(minEmailTime, maxEmailTime + 1);
            yield return new WaitForSeconds(randomTime);

            float randomEmail = Random.Range(0, 10);

            if(randomEmail < 5)
            {
                emailManager.SendGoodEmail();
            }
            else if(randomEmail >= 5)
            {
                emailManager.SendBadEmail();
            }
        }

        yield return new WaitForEndOfFrame();
        StartCoroutine(GenerateEmails());
    }
}
