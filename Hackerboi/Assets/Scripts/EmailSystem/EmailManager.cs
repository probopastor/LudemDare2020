using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailManager : MonoBehaviour
{
    private EmailGenerator eg;

    private List<GameObject> goodEmails = new List<GameObject>();
    private List<GameObject> badEmails = new List<GameObject>();

    private int emailAmount = 10;

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
    }

    public void SendBadEmail()
    {

    }
}
