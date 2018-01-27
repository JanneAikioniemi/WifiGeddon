using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [HideInInspector]
    public CabinUI CabinUi;
    [HideInInspector]
    public ForestUI ForestUi;
    [HideInInspector]
    public MarketUI MarketUi;
    [HideInInspector]
    public WifiTowerUI WifiTowerUi;
    [HideInInspector]
    public MainMenuUI MainMenuUi;
    [HideInInspector]
    public TopMenuUI TopMenuUi;

    void Awake()
    {
        CabinUi = FindObjectOfType<CabinUI>();
        ForestUi = FindObjectOfType<ForestUI>();
        MarketUi = FindObjectOfType<MarketUI>();
        WifiTowerUi = FindObjectOfType<WifiTowerUI>();
        MainMenuUi = FindObjectOfType<MainMenuUI>();
        TopMenuUi = FindObjectOfType<TopMenuUI>();

    }

    public void ShowCabinUi(bool show)
    {
        CabinUi.gameObject.SetActive(show);
    }

    public void ShowForestUi(bool show)
    {
        ForestUi.gameObject.SetActive(show);
    }

    public void ShowMarketUi(bool show)
    {
        MarketUi.gameObject.SetActive(show);
    }

    public void ShowWifiTower(bool show)
    {
        WifiTowerUi.gameObject.SetActive(show);
    }

    public void HideAll()
    {
        ShowForestUi(false);
        ShowCabinUi(false);
        ShowWifiTower(false);
        ShowMarketUi(false);
    }
}
