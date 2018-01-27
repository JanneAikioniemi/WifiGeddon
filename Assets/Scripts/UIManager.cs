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
	[HideInInspector]
	public EndDayUI EndDayUi;


    private RectTransform myTransform;

    void Start()
    {
        CabinUi = transform.GetComponentInChildren<CabinUI>();
        ForestUi = transform.GetComponentInChildren<ForestUI>();
        MarketUi = transform.GetComponentInChildren<MarketUI>();
        WifiTowerUi = transform.GetComponentInChildren<WifiTowerUI>();
        MainMenuUi = transform.GetComponentInChildren<MainMenuUI>();
        TopMenuUi = transform.GetComponentInChildren<TopMenuUI>();
		EndDayUi = transform.GetComponentInChildren<EndDayUI> ();
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
	public void ShowEndDayUi(bool show)
	{
		EndDayUi.gameObject.SetActive (show);
		if (show == true) {
			EndDayUi.EndDayPanel.SetActive (false);
			StartCoroutine (EndDayUi.Fade ());
		}
	}
    public void HideAll()
    {
        ShowForestUi(false);
        ShowCabinUi(false);
        ShowWifiTower(false);
        ShowMarketUi(false);
		ShowEndDayUi (false);
    }
}
