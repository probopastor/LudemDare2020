using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BinaryController : MonoBehaviour
{
    public TextMeshProUGUI settingText;
    public BinaryToggle[] toggles;
    private bool[] pattern = new bool[8];
    private bool[] compArray = new bool[8];

    private void OnEnable()
    {
        CmdPrompt.instance.SetCommandPromptRunning(false);
        settingText.text = "";
        for (int i = 0; i != pattern.Length; i++)
        {
            pattern[i] = (Random.Range(0, 2) == 1);
        }

        foreach (bool myBool in pattern)
        {
            int num;
            if (myBool) num = 1;
            else num = 0;
            settingText.text += num + " ";
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        for (int i = 0; i!= pattern.Length; i++)
        {
            compArray[i] = toggles[i].GetOne();
            if (compArray[i] != pattern[i])
            {
                return;
            }
        }

        CmdPrompt.instance.SetCommandPromptRunning(true);
        gameObject.SetActive(false);
    }
}
