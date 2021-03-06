﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarError : MonoBehaviour
{
    public List<GameObject> buttons = new List<GameObject>();
    private List<GameObject> temp = new List<GameObject>();

    public List<int> nums = new List<int>();

    public float timeToComplete = 15;

    public string result = "";

    public GameObject buttonParents;

    // Start is called before the first frame update
    void Start()
    {
        //string s = GenerateErrorNum();

        for(int i = 0; i < buttonParents.GetComponent<ButtonStore>().children.Length; i++)
        {
            buttons.Add(buttonParents.GetComponent<ButtonStore>().children[i]);
            temp.Add(buttonParents.GetComponent<ButtonStore>().children[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //timeToComplete -= Time.deltaTime;

        //if (timeToComplete <= 0)
        //{
        //    //penalty
        //    Debug.Log("did not finish in time");
        //}
    }

    public string GenerateError()
    {
        result = "";
        int index = 0;
        int count = temp.Count;

        for (int i = 0; i < count; i++)
        {
            index = Random.Range(0, temp.Count);

            result += temp[index].name;

            nums.Add(int.Parse(temp[index].name));

            temp.RemoveAt(index);
        }

        FindObjectOfType<Path>().SetPointArray();
        GetComponent<StarErrorCheck>().order = result.ToCharArray();

        return result;
    }
}
