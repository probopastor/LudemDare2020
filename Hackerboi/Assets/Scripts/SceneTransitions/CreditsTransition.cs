using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsTransition : MonoBehaviour
{
    public Image panel;
    public Color defaultColor;
    public Color toMenuColor;
    private bool filling;

    // Start is called before the first frame update
    void Awake()
    {
        filling = false;
        panel.fillAmount = 1;    
    }

    // Update is called once per frame
    void Update()
    {
        if (!filling)
        {
            panel.color = defaultColor;
            panel.fillAmount -= 0.01f;
        } else
        {
            panel.color = toMenuColor;
            panel.fillAmount += 0.01f;
        }
    }

    public void Menu()
    {
        filling = true;
        Invoke("Switch", 2);
    }

    private void Switch()
    {
        SceneSwitcher.GoTo(0);
    }
}
