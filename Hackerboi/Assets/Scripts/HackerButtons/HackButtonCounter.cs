using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackButtonCounter : MonoBehaviour
{
    public static HackButtonCounter instance;

    private int hackCount = 0;
    private bool isActive;

    public float timer = 5;
    private float currentTime = 0;

    public int buttonPressesToSucceed = 5;

    public GameObject[] buttonObjects;

    public HackButtonsManager hackButtonsManager;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        hackButtonsManager = FindObjectOfType<HackButtonsManager>();
        hackCount = 0;
        timer /= 0.02f;
        currentTime = timer;

        for(int i = 0; i < buttonObjects.Length; i++)
        {
            buttonObjects[i].SetActive(false);
        }

    }

    private void Update()
    {
        Debug.Log("current time " + currentTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isActive)
        {
            currentTime--;

            if(currentTime <= 0)
            {
                LightController.instance.Lose();
                DectivateCounter();
            }

            if (hackCount >= buttonPressesToSucceed)
            {
                DectivateCounter();
            }
        }
    }

    public void ActivateCounter()
    {
        isActive = true;
        hackCount = 0;
        currentTime = timer;

        for (int i = 0; i < buttonPressesToSucceed; i++)
        {
            int randomButton = Random.Range(0, buttonObjects.Length);

            if(buttonObjects[randomButton].activeSelf)
            {
                if(randomButton == 0)
                {
                    randomButton++;
                }
                else
                {
                    randomButton--;
                }
            }

            buttonObjects[randomButton].SetActive(true);
        }
    }

    public void DectivateCounter()
    {
        isActive = false;

        for (int i = 0; i < buttonObjects.Length; i++)
        {
            buttonObjects[i].SetActive(false);
        }

        hackButtonsManager.SolveProblem();
    }

    public void ResetHackCount()
    {
        hackCount = 0;
    }

    public void IncreaseHackCount()
    {
        hackCount++;
    }

    public int GetHackCount()
    {
        return hackCount;
    }
}
