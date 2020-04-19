using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BinaryToggle : MonoBehaviour
{
    private bool one;
    public TextMeshProUGUI text;

    public void Toggle()
    {
        one = !one;
        if (one) text.text = "1";
        else text.text = "0";
    }

    public bool GetOne()
    {
        return one;
    }
}
