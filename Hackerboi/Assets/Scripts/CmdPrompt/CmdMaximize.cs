using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdMaximize : MonoBehaviour
{
    public Animator cmdAnimator;

    public Animator contactsAnimator;

    public Animator emailAnimator;

    public bool doOnce;

    private AudioSource windowAudio;
    public AudioClip maximize;


    void Start()
    {
        windowAudio = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
    }

    /// <summary>
    /// Maximizes the Command Prompt upon clicking it's button
    /// </summary>
    public void ClickCmdMaximize()
    {
        windowAudio.PlayOneShot(maximize);
        cmdAnimator.SetBool("cmdIsMaximized", true);
        cmdAnimator.SetBool("cmdIsMinimized", false);

        CmdPrompt.instance.SetCommandPromptRunning(true);

        //The first time the command prompt is open, run cmdPromptOpen() on the CmdPrompt.
        if(!doOnce)
        {
            doOnce = true;
            CmdPrompt.instance.cmdPromptOpen();
        }
    }

    /// <summary>
    /// Maximizes the Contacts tab upon clicking it's button
    /// </summary>
    public void ClickContactsMaximize()
    {
        windowAudio.PlayOneShot(maximize);
        contactsAnimator.SetBool("ContactsEnabled", true);
        contactsAnimator.SetBool("ContactsDisabled", false);
    }

    public void ClickEmailMaximize()
    {
        windowAudio.PlayOneShot(maximize);
        emailAnimator.SetBool("emailMaximized", true);
        emailAnimator.SetBool("emailMinimized", false);
    }

    public void ClickPatternMinigameMaximize()
    {
        emailAnimator.SetBool("patternOn", true);
        emailAnimator.SetBool("patternOff", false);
    }
}
