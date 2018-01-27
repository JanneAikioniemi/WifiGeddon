using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject CabinUi;
    [SerializeField]
    private GameObject ForestUi;
    [SerializeField]
    private GameObject MarketUi;
    [SerializeField]
    private GameObject WifiTowerUi;

    public void ShowCabinUi(bool show)
    {
        CabinUi.SetActive(show);
    }

    public void ShowForestUi(bool show)
    {
        ForestUi.SetActive(show);
    }

    public void ShowMarketUi(bool show)
    {
        MarketUi.SetActive(show);
    }

    public void ShowWifiTower(bool show)
    {
        WifiTowerUi.SetActive(show);
    }

    public void HideAll()
    {
        ShowForestUi(false);
        ShowCabinUi(false);
        ShowWifiTower(false);
        ShowMarketUi(false);
    }
}
