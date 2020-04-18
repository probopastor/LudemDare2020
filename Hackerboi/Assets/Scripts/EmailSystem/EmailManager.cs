using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailManager : MonoBehaviour
{
    private EmailGenerator eg;

    // Start is called before the first frame update
    void Start()
    {
        eg = GetComponent<EmailGenerator>();
        eg.GenerateGoodEmails();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
