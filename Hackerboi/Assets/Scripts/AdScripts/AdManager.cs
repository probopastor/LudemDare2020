using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdManager : MonoBehaviour
{
    public GameObject[] ads;
    public List<int> selectedAds = new List<int>();

    private int randomAmountOfAds = 0;
    private int randomAd = 0;

    private bool adChosen;

    public GameObject[] henkAds;
    public GameObject[] bigEarsAds;
    public GameObject[] needAFixAds;
    public GameObject[] spearsAds;
    public GameObject[] blindsAds;
    public GameObject[] raveAds;


    private void Start()
    {
        adChosen = true;

        for (int i = 0; i < ads.Length; i++)
        {
            ads[i].SetActive(false);
        }
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            SpawnAds();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            HenkAdSpam();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            BigEarsAdSpam();
        }
        else if(Input.GetKeyDown(KeyCode.Alpha6))
        {
            NeedAFixSpam();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            SpearAdSpam();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            BlindsAdSpam();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            RaveAdSpam();
        }
    }
    
    public void SpawnAds()
    {
        randomAmountOfAds = Random.Range(0, ads.Length + 1);

        for(int i = 0; i < randomAmountOfAds; i++)
        {
            StartCoroutine(EnableAds());
        }
    }

    private IEnumerator EnableAds()
    {
        randomAd = Random.Range(0, randomAmountOfAds + 1);

        if(selectedAds.Count > 0)
        {
            for(int x = 0; x < selectedAds.Count; x++)
            {
                if(selectedAds[x] == randomAd)
                {
                    adChosen = false;
                }
            }
        }

        if(adChosen)
        {
            ads[randomAd].SetActive(true);
        }
        else if(!adChosen)
        {
            yield return new WaitForEndOfFrame();
            StartCoroutine(EnableAds());
        }

        yield return new WaitForEndOfFrame();
    }

    public void HenkAdSpam()
    {
        for(int i = 0; i < henkAds.Length; i++)
        {
            henkAds[i].SetActive(true);
        }
    }

    public void BigEarsAdSpam()
    {
        for (int i = 0; i < bigEarsAds.Length; i++)
        {
            bigEarsAds[i].SetActive(true);
        }
    }

    public void NeedAFixSpam()
    {
        for (int i = 0; i < needAFixAds.Length; i++)
        {
            needAFixAds[i].SetActive(true);
        }
    }

    public void SpearAdSpam()
    {
        for (int i = 0; i < spearsAds.Length; i++)
        {
            spearsAds[i].SetActive(true);
        }
    }

    public void BlindsAdSpam()
    {
        for (int i = 0; i < blindsAds.Length; i++)
        {
            blindsAds[i].SetActive(true);
        }
    }

    public void RaveAdSpam()
    {
        for (int i = 0; i < raveAds.Length; i++)
        {
            raveAds[i].SetActive(true);
        }
    }
}
