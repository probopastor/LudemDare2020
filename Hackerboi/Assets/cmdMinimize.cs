using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cmdMinimize : MonoBehaviour
{
    public Animator cmdAnimator;


    public void MinimizeCmd()
    {
        cmdAnimator.SetTrigger("cmdMinimize");
    }
    





}
