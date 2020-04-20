using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinaryManager : Problem
{
    public GameObject prefab;
    private GameObject curPrefab;
    public GameObject canvas;

    private AudioSource binSource;
    public AudioClip appear;

    public void Start()
    {
        binSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
    }

    public override void CauseProblem()
    {
        if (curPrefab == null)
            curPrefab = Instantiate(prefab, canvas.transform);
        else curPrefab.SetActive(true);
        binSource.PlayOneShot(appear);
    }

    public override void SolveProblem()
    {
        curPrefab.SetActive(false);
    }
}
