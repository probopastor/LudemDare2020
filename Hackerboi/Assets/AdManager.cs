using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdManager : MonoBehaviour
{
    #region variables
    public GameObject ad;
    public GameObject canvas;
    #endregion


    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            CloseAd();
        }
    }

    public void CloseAd()
    {
        Vector3 newPosition = new Vector3(Random.Range(-6.4f, 6.4f), Random.Range(-3.5f, 3.5f), 0);

       var newAd =  Instantiate(ad, newPosition, Quaternion.identity);
        newAd.transform.parent = canvas.transform;
        //print(position);
        //ad.transform.position = position;
        //position = Vector3.zero;
        //ad.SetActive(false);
    }





}
