/************************************************************************************************
// File Name:   Music Tracker.cs
// Author:      Jake Hyland
// Description: Contains a function for establishing the background music track being played in any given scene
//              Takes into account any new object that plays music if it has the "Music" tag
************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTracker : MonoBehaviour
{

    //Finds if the scene includes a Music playing object and destroys the new music
    //If there isn't any new music, the object is not destroyed

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");

        if (objs.Length > 1)
        {
            Destroy(objs[1]);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void Stop() //Deletes the Current Music Playing Object after 5 seconds
    {
        StartCoroutine(Deletion());
    }

    public IEnumerator Deletion()
    {
        yield return new WaitForSeconds(6.25f);
        Destroy(gameObject);
    }
}
