using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCanvasAtStart : MonoBehaviour
{
    private bool runOnce = false;
    public GameObject canvas;

    // Update is called once per frame
    void Update()
    {
        if (runOnce == false)
        {
            runOnce = true;
            canvas.SetActive(true);
        }
    }
}
