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

    private int wifiBandsActive = 0;
    private bool firstBandEnableChecked;
    private bool secondBandEnableChecked;
    private bool thirdBandEnableChecked;

    private bool firstBandDisableChecked;
    private bool secondBandDisableChecked;
    private bool thirdBandDisableChecked;

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
        CheckEnabledBands();
        EnableBands();

        //if (!LightController.instance.GetRouterStatus() && wifiSymbolOnScreen)
        //{
        //    wifiBand1.SetActive(false);
        //    wifiBand2.SetActive(false);
        //    wifiBand3.SetActive(false);
        //    wifiBand4.SetActive(false);
        //    noWifiSymbol.SetActive(true);
        //}
        //else if (LightController.instance.GetRouterStatus() && wifiSymbolOnScreen)
        //{
        //    wifiBand1.SetActive(true);
        //    wifiBand2.SetActive(true);
        //    wifiBand3.SetActive(true);
        //    wifiBand4.SetActive(true);
        //    noWifiSymbol.SetActive(false);
        //}
        //else if(!wifiSymbolOnScreen)
        //{
        //    wifiBand1.SetActive(false);
        //    wifiBand2.SetActive(false);
        //    wifiBand3.SetActive(false);
        //    wifiBand4.SetActive(false);
        //    noWifiSymbol.SetActive(false);
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha4))
        //{
        //    LightController.instance.Compromise(0);
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha5))
        //{
        //    LightController.instance.Compromise(1);
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha6))
        //{
        //    LightController.instance.Compromise(2);
        //}

        //if (Input.GetKeyDown(KeyCode.U))
        //{
        //    LightController.instance.Lose(0);
        //}
        //if (Input.GetKeyDown(KeyCode.I))
        //{
        //    LightController.instance.Lose(1);
        //}
        //if (Input.GetKeyDown(KeyCode.O))
        //{
        //    LightController.instance.Lose(2);
        //}
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

    private void CheckEnabledBands()
    {
        if (wifiSymbolOnScreen)
        {
            if (!LightController.instance.LineLost(0))
            {
                if (!firstBandEnableChecked)
                {
                    firstBandEnableChecked = true;
                    wifiBandsActive++;
                }
            }
            else
            {
                if (!firstBandDisableChecked)
                {
                    firstBandDisableChecked = true;
                    wifiBandsActive--;
                }
            }

            if (!LightController.instance.LineLost(1))
            {
                if (!secondBandEnableChecked)
                {
                    secondBandEnableChecked = true;
                    wifiBandsActive++;
                }
            }
            else
            {
                if (!secondBandDisableChecked)
                {
                    secondBandDisableChecked = true;
                    wifiBandsActive--;
                }
            }

            if (!LightController.instance.LineLost(2))
            {
                if (!thirdBandEnableChecked)
                {
                    thirdBandEnableChecked = true;
                    wifiBandsActive++;
                }
            }
            else
            {
                if (!thirdBandDisableChecked)
                {
                    thirdBandDisableChecked = true;
                    wifiBandsActive--;
                }
            }
        }
    }

    private void EnableBands()
    {
        if (LightController.instance.GetRouterStatus() && wifiSymbolOnScreen)
        {
            if (wifiBandsActive == 1)
            {
                wifiBand1.SetActive(true);
                wifiBand2.SetActive(false);
                wifiBand3.SetActive(false);
                wifiBand4.SetActive(false);
                noWifiSymbol.SetActive(false);
            }
            else if (wifiBandsActive == 2)
            {
                wifiBand1.SetActive(true);
                wifiBand2.SetActive(true);
                wifiBand3.SetActive(true);
                wifiBand4.SetActive(false);
                noWifiSymbol.SetActive(false);
            }
            else if (wifiBandsActive == 3)
            {
                wifiBand1.SetActive(true);
                wifiBand2.SetActive(true);
                wifiBand3.SetActive(true);
                wifiBand4.SetActive(true);
                noWifiSymbol.SetActive(false);
            }
            else if(wifiBandsActive == 0)
            {
                wifiBand1.SetActive(false);
                wifiBand2.SetActive(false);
                wifiBand3.SetActive(false);
                wifiBand4.SetActive(false);
                noWifiSymbol.SetActive(true);
            }
        }
        else if (!LightController.instance.GetRouterStatus() && wifiSymbolOnScreen)
        {
            wifiBand1.SetActive(false);
            wifiBand2.SetActive(false);
            wifiBand3.SetActive(false);
            wifiBand4.SetActive(false);
            noWifiSymbol.SetActive(true);
        }
        else if(wifiBandsActive == 0 && wifiSymbolOnScreen)
        {
            wifiBand1.SetActive(false);
            wifiBand2.SetActive(false);
            wifiBand3.SetActive(false);
            wifiBand4.SetActive(false);
            noWifiSymbol.SetActive(true);
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
}
