using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdManager : MonoBehaviour
{
    #region variables
    public GameObject adPrefab;
    public GameObject canvas;
    public GameObject adInstance;
    #endregion




    public void SpawnAds()
    {

        Vector3 newPosition = new Vector3(Random.Range(-6.4f, 6.4f), Random.Range(-3.5f, 3.5f), 0);

        var newAd = Instantiate(adPrefab, newPosition, Quaternion.identity);
        //newAd.transform.parent = canvas.transform;
        newAd.transform.SetParent(canvas.transform);
    }
    public void CloseAd()
    {
        Destroy(adInstance);
        
    }





}
