using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactsMinimize : MonoBehaviour
{
    public Animator contactsAnimator;

    private AudioSource miniAudio;
    public AudioClip minimize;

    void Start()
    {
        miniAudio = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
    }

    public void MinimizeCmd()
    {
       miniAudio.PlayOneShot(minimize);
       contactsAnimator.SetBool("ContactsEnabled", false);
       contactsAnimator.SetBool("ContactsDisabled", true);
    }
}
