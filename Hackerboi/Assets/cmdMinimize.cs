using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cmdMinimize : MonoBehaviour
{
    public Animator cmdAnimator;
    public Hackboi HB;

    public void MinimizeCmd()
    {
        cmdAnimator.SetTrigger("cmdMinimize");
        HB.cmdPromptOpen(false);
    }
}
