using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdInstance : MonoBehaviour
{

    public GameObject adInstance;


    public void CloseAd()
    {
        Destroy(adInstance);
    }
}
