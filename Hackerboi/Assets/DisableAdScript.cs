using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAdScript : MonoBehaviour
{

    public GameObject thisAd;

    // Start is called before the first frame update
    

    public void DisableThisAd()
    {
        thisAd.SetActive(false);
    }
}
