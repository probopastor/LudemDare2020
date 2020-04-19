using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WifiUIController : MonoBehaviour
{
    public GameObject wifiBand1;
    public GameObject wifiBand2;
    public GameObject wifiBand3;
    public GameObject wifiBand4;
    public GameObject noWifiSymbol;

    // Start is called before the first frame update
    void Start()
    {
        wifiBand1.SetActive(true);
        wifiBand2.SetActive(true);
        wifiBand3.SetActive(true);
        wifiBand4.SetActive(true);
        noWifiSymbol.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
