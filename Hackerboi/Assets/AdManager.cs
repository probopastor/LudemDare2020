using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdManager : MonoBehaviour
{
    #region variables
    public GameObject ad;
    #endregion



    public void CloseAd()
    {
        Vector3 position = new Vector3(Random.Range(-750.0f, 750.0f), Random.Range(-391.0f, 387.0f), 0);
        print(position);
        ad.transform.position = position;
        position = Vector3.zero;
        //ad.SetActive(false);
    }





}
