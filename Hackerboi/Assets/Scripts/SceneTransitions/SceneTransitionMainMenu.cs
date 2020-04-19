using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SceneTransitionMainMenu : MonoBehaviour
{
    public Image panel;
    private ParticleSystem ps;

    private int settingParam;

    private bool switching;

    // Start is called before the first frame update
    void Start()
    {
        switching = false;
        ps = GetComponent<ParticleSystem>();
        ps.Stop();
    }

    public void Transition(int scene)
    {
        Invoke("SwitchOn", 3);
        ps.Play();
        settingParam = scene;
        Invoke("AdvanceScene", 8);
    }

    private void SwitchOn()
    {
        switching = true;
    }

    private void FixedUpdate()
    {
        if (switching)
        {
            panel.fillAmount += 0.01f;
        }
    }

    private void AdvanceScene()
    {
        SceneSwitcher.GoTo(settingParam);
    }
}
