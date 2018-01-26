using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ViewType
{
    Cabin,
    Market,
    Forest,
    WifiTower
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject CabinUi;
    public GameObject ForestUi;
    public GameObject MarketUi;
    public GameObject WifiTowerUi;

    void Awake()
    {
        if (Instance != null) return;
        Instance = this;
    }

    void Start()
    {
        SwitchView(ViewType.Cabin);
    }

    public void SwitchView(ViewType view)
    {
        HideAllUIs();

        switch (view)
        {
            case ViewType.Cabin:
                SwitchToCabinView();
                break;

            case ViewType.Market:
                SwitchToMarketView();
                break;

            case ViewType.Forest:
                SwitchToForestView();
                break;

            case ViewType.WifiTower:
                SwitchToWifiTower();
                break;

            default:

                throw new ArgumentOutOfRangeException("view", view, null);
        }
    }

    private void SwitchToWifiTower()
    {
        WifiTowerUi.SetActive(true);
    }

    private void SwitchToMarketView()
    {
        MarketUi.SetActive(true);
    }

    private void SwitchToForestView()
    {
        ForestUi.SetActive(true);
    }

    private void SwitchToCabinView()
    {
        CabinUi.SetActive(true);
    }

    private void HideAllUIs()
    {
        ForestUi.SetActive(false);
        CabinUi.SetActive(false);
        WifiTowerUi.SetActive(false);
        MarketUi.SetActive(false);
    }
}
