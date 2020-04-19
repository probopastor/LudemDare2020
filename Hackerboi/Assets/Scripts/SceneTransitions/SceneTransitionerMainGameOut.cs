using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneTransitionerMainGameOut : MonoBehaviour
{
    public Image cracks;

    public Image panel;

    private bool lost;
    private bool fade;

    // Start is called before the first frame update
    void Start()
    {
        lost = false;
        fade = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (fade)
        {
            panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, panel.color.a + 0.0125f);
        }

        if (lost)
        {
            cracks.fillAmount += 0.01f;
        }
    }

    public void Lose()
    {
        Invoke("Fade", 2);
        Invoke("Switch", 4);
        lost = true;
    }

    void Fade()
    {
        fade = true;
    }

    void Switch()
    {
        SceneSwitcher.GoTo(2);
    }
}
