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

    [SerializeField] private UIManager uiManager;
    [SerializeField] private GameObject cabinScene;
    [SerializeField] private GameObject forestScene;
    [SerializeField] private GameObject marketScene;
    [SerializeField] private GameObject wifiScene;

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
        HideAll();

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
        uiManager.ShowWifiTower(true);
        wifiScene.SetActive(true);
    }

    private void SwitchToMarketView()
    {
        uiManager.ShowMarketUi(true);
        marketScene.SetActive(true);
    }

    private void SwitchToForestView()
    {
        uiManager.ShowForestUi(true);
        forestScene.SetActive(true);
    }

    private void SwitchToCabinView()
    {
        uiManager.ShowCabinUi(true);
        cabinScene.SetActive(true);
    }

    private void HideAll()
    {
        uiManager.HideAll();

        cabinScene.SetActive(false);
        forestScene.SetActive(false);
        marketScene.SetActive(false);
        wifiScene.SetActive(false);
    }
}
