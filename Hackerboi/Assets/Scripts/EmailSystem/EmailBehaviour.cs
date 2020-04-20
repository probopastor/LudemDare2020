using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailBehaviour : MonoBehaviour
{
    private Email e;

    public GameObject replyButton;
    public GameObject deleteButton;
    public GameObject responseImg;
    public GameObject bodyImg;

    public bool hasOpened = false;
    public float timeToOpen = 10;

    public bool isTimed = false;

    private AudioSource emailAudio;
    public AudioClip goodSend, badSend, badTrash, goodReply, mehReply, badReply, trashed;

    // Start is called before the first frame update
    void Start()
    {
        e = GetComponent<Email>();
        emailAudio = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
    }

    public void Update()
    {
        //if(hasOpened == false && isTimed == true)
        //{
        //    timeToOpen -= Time.deltaTime;
        //}

        //if(timeToOpen <= 0)
        //{
        //    //penalty
        //    Debug.Log("did not open in time");
        //    hasOpened = false;
        //    timeToOpen = 10;
        //    gameObject.SetActive(false);
        //}
    }

    public void DeleteButton()
    {
        FindObjectOfType<EmailManager>().EmailNotificationOff();

        if (e.isBad == true)
        {
            //corrent response for bad email
            Debug.Log("pass");
            gameObject.SetActive(false);
            emailAudio.PlayOneShot((trashed), 0.95F);
        }

        else if(e.isBad == false)
        {
            //wrong response for good email
            //call for penalty
            Debug.Log("penalty");
            gameObject.SetActive(false);
            emailAudio.PlayOneShot((badTrash), 0.8f);
        }

        else
        {
            Destroy(gameObject);
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
            e.BadEffect();
            emailAudio.PlayOneShot((badSend), 0.8f);
        }

        else
        {
            //correct response for good email
            replyButton.SetActive(false);
            deleteButton.SetActive(false);
            emailAudio.PlayOneShot((goodSend), 0.8f);

            responseImg.SetActive(true);

        }
    }

    public void OpenEmail()
    {
        FindObjectOfType<EmailManager>().EmailNotificationOff();

        bodyImg.SetActive(true);
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
            emailAudio.PlayOneShot((mehReply), 0.8f);
        }

        if (rb.type == 3) //bad
        {
            //worst response
            //call for penalty
            Debug.Log("fuck");
            emailAudio.PlayOneShot((badReply), 0.8f);
        }

        gameObject.transform.GetChild(4).gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
