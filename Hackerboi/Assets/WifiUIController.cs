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

    public GameObject arrowToRouter;
    private bool wifiSymbolOnScreen;

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
        CheckOnComputerScreen();

        if (!LightController.instance.GetRouterStatus() && wifiSymbolOnScreen)
        {
            wifiBand1.SetActive(false);
            wifiBand2.SetActive(false);
            wifiBand3.SetActive(false);
            wifiBand4.SetActive(false);
            noWifiSymbol.SetActive(true);
        }
        else if (LightController.instance.GetRouterStatus() && wifiSymbolOnScreen)
        {
            wifiBand1.SetActive(true);
            wifiBand2.SetActive(true);
            wifiBand3.SetActive(true);
            wifiBand4.SetActive(true);
            noWifiSymbol.SetActive(false);
        }
        else if(!wifiSymbolOnScreen)
        {
            wifiBand1.SetActive(false);
            wifiBand2.SetActive(false);
            wifiBand3.SetActive(false);
            wifiBand4.SetActive(false);
            noWifiSymbol.SetActive(false);
        }
    }

    private void CheckOnComputerScreen()
    {
        if(arrowToRouter.GetComponent<SlideToRouter>().isShifted())
        {
            wifiSymbolOnScreen = true;
        }
        else if(!arrowToRouter.GetComponent<SlideToRouter>().isShifted())
        {
            wifiSymbolOnScreen = false;
        }
    }
}
