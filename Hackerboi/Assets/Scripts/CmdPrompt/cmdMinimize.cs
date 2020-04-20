using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cmdMinimize : MonoBehaviour
{
    public Animator cmdAnimator;

    public Animator emailAnimator;

    public Animator howToPlayAnimator;

    public Animator patternAnimator;

    public Animator coordinateAnimator;

    private AudioSource windowAudio;
    public AudioClip minimize;

    /// <summary>
    /// Minimizes the Command Prompt upon clicking it's close button
    /// </summary>
    /// 

    void Start()
    {
        windowAudio = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
    }

    public void MinimizeCmd()
    {
        windowAudio.PlayOneShot(minimize);
        cmdAnimator.SetBool("cmdIsMinimized", true);
        cmdAnimator.SetBool("cmdIsMaximized", false);

        CmdPrompt.instance.SetCommandPromptRunning(false);
    }

    public void MinimizeEmail()
    {
        windowAudio.PlayOneShot(minimize);
        emailAnimator.SetBool("emailMinimized", true);
        emailAnimator.SetBool("emailMaximized", false);
    }

    public void MinimizePatternMinigame()
    {
        windowAudio.PlayOneShot(minimize);
        patternAnimator.SetBool("PatternOff", true);
        patternAnimator.SetBool("PatternOn", false);
    }

    public void ClickHowToPlayMinimize()
    {
        windowAudio.PlayOneShot(minimize);
        howToPlayAnimator.SetBool("HowToPlayMaximized", false);
        howToPlayAnimator.SetBool("HowToPlayMinimized", true);

    }

    public void ClickCoordinateMinigameMinimize()
    {
        windowAudio.PlayOneShot(minimize);
        coordinateAnimator.SetBool("CoorOff", true);
        coordinateAnimator.SetBool("CoorOn", false);
    }
}
