using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdManager : MonoBehaviour
{
    public AudioSource MusicSource;
    public AudioSource SecondMusicSource;

    public AudioSource SoundEffectSource;

    public AudioClip adPopupSound;

    public AudioClip henkMusic;
    public AudioClip bigEarsMusic;
    public AudioClip needAFixMusic;
    public AudioClip spearsMusic;
    public AudioClip blindsMusic;
    public AudioClip raveMusic;


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
        //if(Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    SpawnAds();
        //}
        //else if (Input.GetKeyDown(KeyCode.Alpha4))
        //{
        //    HenkAdSpam();
        //}
        //else if (Input.GetKeyDown(KeyCode.Alpha5))
        //{
        //    BigEarsAdSpam();
        //}
        //else if(Input.GetKeyDown(KeyCode.Alpha6))
        //{
        //    NeedAFixSpam();
        //}
        //else if (Input.GetKeyDown(KeyCode.Alpha7))
        //{
        //    SpearAdSpam();
        //}
        //else if (Input.GetKeyDown(KeyCode.Alpha8))
        //{
        //    BlindsAdSpam();
        //}
        //else if (Input.GetKeyDown(KeyCode.Alpha9))
        //{
        //    RaveAdSpam();
        //}
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
            SoundEffectSource.clip = adPopupSound;
            SoundEffectSource.Play();
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
        MusicSource.Pause();
        SecondMusicSource.clip = henkMusic;
        SecondMusicSource.Play();

        for (int i = 0; i < henkAds.Length; i++)
        {
            henkAds[i].SetActive(true);
            SoundEffectSource.clip = adPopupSound;
            SoundEffectSource.Play();
        }

        StartCoroutine(StopAdMusic(henkAds));
    }

    public void BigEarsAdSpam()
    {
        MusicSource.Pause();
        SecondMusicSource.clip = bigEarsMusic;
        SecondMusicSource.Play();

        for (int i = 0; i < bigEarsAds.Length; i++)
        {
            bigEarsAds[i].SetActive(true);
            SoundEffectSource.clip = adPopupSound;
            SoundEffectSource.Play();
        }

        StartCoroutine(StopAdMusic(bigEarsAds));
    }

    public void NeedAFixSpam()
    {
        MusicSource.Pause();
        SecondMusicSource.clip = needAFixMusic;
        SecondMusicSource.Play();

        for (int i = 0; i < needAFixAds.Length; i++)
        {
            needAFixAds[i].SetActive(true);
            SoundEffectSource.clip = adPopupSound;
            SoundEffectSource.Play();
        }

        StartCoroutine(StopAdMusic(needAFixAds));
    }

    public void SpearAdSpam()
    {
        MusicSource.Pause();
        SecondMusicSource.clip = spearsMusic;
        SecondMusicSource.Play();

        for (int i = 0; i < spearsAds.Length; i++)
        {
            spearsAds[i].SetActive(true);
            SoundEffectSource.clip = adPopupSound;
            SoundEffectSource.Play();
        }

        StartCoroutine(StopAdMusic(spearsAds));
    }

    public void BlindsAdSpam()
    {
        MusicSource.Pause();
        SecondMusicSource.clip = blindsMusic;
        SecondMusicSource.Play();

        for (int i = 0; i < blindsAds.Length; i++)
        {
            blindsAds[i].SetActive(true);
            SoundEffectSource.clip = adPopupSound;
            SoundEffectSource.Play();
        }

        StartCoroutine(StopAdMusic(blindsAds));
    }

    public void RaveAdSpam()
    {
        MusicSource.Pause();
        SecondMusicSource.clip = raveMusic;
        SecondMusicSource.Play();

        for (int i = 0; i < raveAds.Length; i++)
        {
            raveAds[i].SetActive(true);
            SoundEffectSource.clip = adPopupSound;
            SoundEffectSource.Play();
        }

        StartCoroutine(StopAdMusic(raveAds));
    }

    private IEnumerator StopAdMusic(GameObject[] currentAdArray)
    {
        int objectsActive = 0;

        for(int i = 0; i < currentAdArray.Length; i++)
        {
            if(currentAdArray[i].activeSelf)
            {
                objectsActive++;
            }
        }

        if (objectsActive > 0)
        {
            yield return new WaitForEndOfFrame();
            StartCoroutine(StopAdMusic(currentAdArray));
        }
        else
        {
            SecondMusicSource.Pause();
            MusicSource.UnPause();
        }

        yield return new WaitForEndOfFrame();
    }
}
