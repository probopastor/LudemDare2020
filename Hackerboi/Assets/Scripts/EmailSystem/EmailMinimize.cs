using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailMinimize : MonoBehaviour
{
    public Animator emailAnimator;

    public void MinimizeCmd()
    {
        emailAnimator.SetBool("EmailEnabled", false);
        emailAnimator.SetBool("EmailDisabled", true);
    }
}
