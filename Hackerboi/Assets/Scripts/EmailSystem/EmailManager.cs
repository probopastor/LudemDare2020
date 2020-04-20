using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailManager : MonoBehaviour
{
    private EmailGenerator eg;

    private List<GameObject> goodEmails = new List<GameObject>();
    private List<GameObject> badEmails = new List<GameObject>();

    private int emailAmount = 10;

    public GameObject notificationImage;

    private EventManager eventManager;
    private bool errorInProgress;
    private int errorIndex = 0;

    private AudioSource emailAudio;
    public AudioClip gotEmailSound;

    // Start is called before the first frame update
    void Start()
    {
        eventManager = FindObjectOfType<EventManager>();
        eg = GetComponent<EmailGenerator>();
        //eg.GenerateGoodEmails();
        CreateEmailList();
        emailAudio = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //case numbers to be changed later
        //switch (eventManager.GetEventIndex())
        //{
        //    case 0:
        //        errorInProgress = false;
        //        break;
        //    case 1:
        //        errorInProgress = true;
        //        errorIndex = 0;
        //        CreatePasswordEmail();
        //        break;
        //    case 2:
        //        errorInProgress = true;
        //        errorIndex = 0;
        //        CreateProgramEmail();
        //        break;
        //    default:
        //        break;
        //}

        //if(Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    SendGoodEmail();
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    SendBadEmail();
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    CreatePasswordEmail();
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    CreateProgramEmail();
        //}


    }

    public void CreateEmailList()
    {
        for(int i = 0; i < emailAmount; i++)
        {
            goodEmails.Add(eg.GenerateGoodEmails());
            badEmails.Add(eg.GenerateBadEmails());
            goodEmails[i].SetActive(false);
            badEmails[i].SetActive(false);
        }
    }

    public void SendGoodEmail()
    {
        int randEmail = Random.Range(0, goodEmails.Count);

        goodEmails[randEmail].GetComponent<Email>().SetDateTime();
        goodEmails[randEmail].SetActive(true);

        EmailNotificationOn();
    }

    public void SendBadEmail()
    {
        int randEmail = Random.Range(0, badEmails.Count);

        badEmails[randEmail].SetActive(true);

        EmailNotificationOn();
    }

    public void EmailNotificationOn()
    {
        emailAudio.PlayOneShot((gotEmailSound), 0.7F);
        Debug.Log("new email alert");
        notificationImage.SetActive(true);
    }

    public void EmailNotificationOff()
    {
        Debug.Log("email checked");
        notificationImage.SetActive(false);
    }

    public GameObject CreatePasswordEmail()
    {
        EmailNotificationOn();
        return eg.GeneratePasswordEmail();
    }

    public GameObject CreateProgramEmail()
    {
        EmailNotificationOn();
        return eg.GenerateProgramEmail();
    }

    public EmailGenerator GetEmailGenerator()
    {
        return eg;
    }
}
