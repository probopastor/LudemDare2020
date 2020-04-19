using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackButtonController : MonoBehaviour
{
    /// <summary>
    /// Increases the hack count when button is clicked and deactivates the button.
    /// </summary>
    public void ButtonClick()
    {
        HackButtonCounter.instance.IncreaseHackCount();
        gameObject.SetActive(false);
    }
}
