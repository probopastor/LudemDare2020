using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadController : MonoBehaviour
{
    public static HeadController instance;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        instance = this;
    }

    public void Startle()
    {
        anim.SetBool("Startled", true);
        Invoke("NoStartle", 2);
    }

    private void NoStartle()
    {
        anim.SetBool("Startled", false);
    }
}
