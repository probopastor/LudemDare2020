using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdMaximize : MonoBehaviour
{
    public Animator cmdAnimator;
    public Hackboi HB;

    public void ClickCmdMaximize()
    {
        cmdAnimator.SetTrigger("cmdMaximize");
        HB.cmdPromptOpen(true);

    }
}
