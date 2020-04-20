using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverToMainMenu : MonoBehaviour
{

    public Image panel;
    private bool fill;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fill)
        {
            panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, panel.color.a + 0.01f);
        }
    }

    public void Menu()
    {
        fill = true;
        Invoke("Switch", 2);
    }

    private void Switch()
    {
        SceneSwitcher.GoTo(0);
    }
}
