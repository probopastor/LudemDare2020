using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackTimeManager : Problem
{
    public GameObject hackTimer;
    public override void CauseProblem()
    {
        Instantiate(hackTimer, transform.position, Quaternion.identity, transform);
    }

    public override void SolveProblem()
    {
        throw new System.NotImplementedException();
    }
}
