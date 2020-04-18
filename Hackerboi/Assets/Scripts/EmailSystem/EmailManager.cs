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

    // Start is called before the first frame update
    void Start()
    {
        eg = GetComponent<EmailGenerator>();
        //eg.GenerateGoodEmails();
        CreateEmailList();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SendGoodEmail();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SendBadEmail();
        }
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
        Debug.Log("new email alert");
        notificationImage.SetActive(true);
    }

    public void EmailNotificationOff()
    {
        Debug.Log("email checked");
        notificationImage.SetActive(false);
    }
}
