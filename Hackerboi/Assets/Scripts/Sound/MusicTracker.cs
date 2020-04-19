using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTracker : MonoBehaviour
{

    //Finds if the scene includes a Music playing object and destroys the new music
    //If there isn't any new music, the object is not destroyed

    public GameObject[] objs;

    void Start()
    {
       GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");

        if (objs.Length > 1)
        {
            Destroy(objs[1]);
        }

        DontDestroyOnLoad(objs[0]);
    } 
}
