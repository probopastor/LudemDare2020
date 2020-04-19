using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackButtonController : MonoBehaviour
{
    public void ButtonClick()
    {
        HackButtonCounter.instance.IncreaseHackCount();
        gameObject.SetActive(false);
    }
}
