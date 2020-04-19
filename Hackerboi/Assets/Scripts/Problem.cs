using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Problem : MonoBehaviour
{
    public abstract void CauseProblem();
    public abstract void SolveProblem();
}

