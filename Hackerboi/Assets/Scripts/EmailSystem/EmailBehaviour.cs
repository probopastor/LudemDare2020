using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailBehaviour : MonoBehaviour
{
    private Email e;

    public GameObject replyButton;
    public GameObject deleteButton;
    public GameObject responseImg;

    // Start is called before the first frame update
    void Start()
    {
        e = GetComponent<Email>();
    }

    public void DeleteButton()
    {
        FindObjectOfType<EmailManager>().EmailNotificationOff();

        if (e.isBad == true)
        {
            //corrent response for bad email
            Debug.Log("pass");
            gameObject.SetActive(false);
        }

        else
        {
            //wrong response for good email
            //call for penalty
            Debug.Log("penalty");
            gameObject.SetActive(false);
        }

        
    }

    public void Reply()
    {
        FindObjectOfType<EmailManager>().EmailNotificationOff();

        if (e.isBad == true)
        {
            //wrong response for bad email
            //call for penalty
            Debug.Log("penalty");
            gameObject.SetActive(false);
        }

        else
        {
            //correct response for good email
            replyButton.SetActive(false);
            deleteButton.SetActive(false);

            responseImg.SetActive(true);
        }
    }

    public void ResponseActions(ResponseBehaviour rb)
    {
        if(rb.type == 1) //good
        {
            //best response
            //gives a bonus?
            Debug.Log("good");
        }

        if (rb.type == 2) //neutral
        {
            //ok response 
            //just passed no good or bad
            Debug.Log("eh"); 
        }

        if (rb.type == 3) //bad
        {
            //worst response
            //call for penalty
            Debug.Log("fuck");
        }

        gameObject.transform.GetChild(4).gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
