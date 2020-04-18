using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdManager : MonoBehaviour
{
    #region variables
    public GameObject adPrefab;
    public GameObject canvas;
    public int amountOfAds = 4;
    #endregion


    public void SpawnAds()
    {
        for (int i = 0; i < amountOfAds; i++)
        {
            Vector3 newPosition = new Vector3(Random.Range(-6.4f, 6.4f), Random.Range(-3.5f, 3.5f), 0);

            var newAd = Instantiate(adPrefab, newPosition, Quaternion.identity);
            
            newAd.transform.SetParent(canvas.transform);
        }
    }
 }
