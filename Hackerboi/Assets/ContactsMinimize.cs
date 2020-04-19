using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactsMinimize : MonoBehaviour
{
    public Animator contactsAnimator;

    public void MinimizeCmd()
    {
       contactsAnimator.SetBool("ContactsEnabled", false);
       contactsAnimator.SetBool("ContactsDisabled", true);
    }
}
