using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinaryManager : Problem
{
    public GameObject prefab;
    private GameObject curPrefab;
    public GameObject canvas;

    public override void CauseProblem()
    {
        if (curPrefab == null)
            curPrefab = Instantiate(prefab, canvas.transform);
        else curPrefab.SetActive(true);
    }

    public override void SolveProblem()
    {
        curPrefab.SetActive(false);
    }
}
