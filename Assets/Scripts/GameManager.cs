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
    public GameObject BuyButtonPrefab;

    [SerializeField] public UIManager uiManager;
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
		forestScene.SetActive (false);
    }

    public void StartGame()
    {
        uiManager.MainMenuUi.gameObject.SetActive(false);
		uiManager.ShowEndDayUi (false);
        SwitchView(ViewType.Cabin);
    }
	void Update()
	{
		if (ResourceManager.Instance.TimeLeftForRound <= 0) {			
			EndDay ();
			ResourceManager.Instance.ResetRound ();
		}
	}
	public void EndDay()
	{
		uiManager.ShowEndDayUi (true);
		//ResourceManager.Instance.ResetRound ();
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
