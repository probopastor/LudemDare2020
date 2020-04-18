using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdMaximize : MonoBehaviour
{
    public Animator cmdAnimator;

    public void ClickCmdMaximize()
    {
        cmdAnimator.SetTrigger("cmdMaximize");
    }

}
