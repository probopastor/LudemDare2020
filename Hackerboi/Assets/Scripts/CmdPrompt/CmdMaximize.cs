using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdMaximize : MonoBehaviour
{
    public Animator cmdAnimator;

    public Animator contactsAnimator;

    public Animator emailAnimator;

    public Animator howToPlayAnimator;

    public Animator patternAnimator;

    public Animator coordinateAnimator;

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
        windowAudio.PlayOneShot(maximize);
        patternAnimator.SetBool("PatternOn", true);
        patternAnimator.SetBool("PatternOff", false);
    }

    public void ClickHowToPlayMaximize()
    {
        windowAudio.PlayOneShot(maximize);
        howToPlayAnimator.SetBool("HowToPlayMaximized", true);
        howToPlayAnimator.SetBool("HowToPlayMinimized", false);
        
    }

    public void ClickCoordinateMinigameMaximize()
    {
        windowAudio.PlayOneShot(maximize);
        coordinateAnimator.SetBool("CoorOn", true);
        coordinateAnimator.SetBool("CoorOff", false);
    }
}
