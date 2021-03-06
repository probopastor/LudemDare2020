﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarErrorCheck : MonoBehaviour
{
    public char[] order = new char[8];

    public int pos = 0;

    private int check;

    public CompleteProgramError cpe;

    private AudioSource starAudio;
    public AudioClip good, bad;

    // Start is called before the first frame update
    void Start()
    {
       starAudio = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            order = GetComponent<StarError>().result.ToCharArray();
        }
    }

    public void ButtonCheck(int num)
    {
        check = num;

        //Debug.Log("here" + order[pos]);
        if(order[pos].ToString().Equals(num.ToString()))
        {
            pos++;
            starAudio.PlayOneShot((good), 0.7f);
            StartCoroutine("ChangeColorGood");
            //FindObjectOfType<Path>().DrawLine();

            if (pos == 8)
            {
                //turn off error
                Debug.Log("finsihed correct");
                for(int i = 0; i < gameObject.GetComponent<StarError>().buttons.Count; i++)
                {
                    gameObject.GetComponent<StarError>().buttons[i].GetComponent<Image>().color = Color.white;
                }

                gameObject.GetComponent<StarError>().buttonParents.transform.GetChild(8).GetComponent<cmdMinimize>().MinimizePatternMinigame();

                cpe.SolveProblem();
            }
        }

        else
        {
            starAudio.PlayOneShot((bad), 0.7f);
            Debug.Log("incorrect");
            StartCoroutine("ChangeColorBad");
        }
    }

    IEnumerator ChangeColorGood()
    {
        GetComponent<StarError>().buttons[check - 1].GetComponent<Image>().color = Color.green;
        yield return new WaitForSeconds(.01f);
        //GetComponent<StarError>().buttons[check - 1].GetComponent<Image>().color = Color.white;
    }

    IEnumerator ChangeColorBad()
    {
        GetComponent<StarError>().buttons[check - 1].GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(.25f);
        GetComponent<StarError>().buttons[check - 1].GetComponent<Image>().color = Color.white;
    }
}
