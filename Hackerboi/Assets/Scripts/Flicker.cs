using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Flicker : MonoBehaviour
{
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Toggle", 0, 2);
    }

    void Toggle()
    {
        text.enabled = !text.enabled;
    }

}
