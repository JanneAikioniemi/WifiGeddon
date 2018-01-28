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
        forestScene.SetActive(false);
    }

    public void StartGame()
    {
        uiManager.MainMenuUi.gameObject.SetActive(false);
        uiManager.ShowEndDayUi(false);
        SwitchView(ViewType.Cabin);
    }
    void Update()
    {
        if (ResourceManager.Instance.TimeLeftForRound <= 0)
        {
            EndDay();
            ResourceManager.Instance.ResetRound();
        }
    }
    public void EndDay()
    {
        uiManager.ShowEndDayUi(true);
        uiManager.MarketUi.RefreshStores();
		uiManager.WifiTowerUi.ResetUI ();
    }
	public void Win()
	{
		uiManager.WinUi.EndGamePanel.SetActive (true);
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
		marketScene.GetComponent<AudioSource> ().Stop ();
		wifiScene.GetComponent<AudioSource> ().Play ();
    }

    private void SwitchToMarketView()
    {
        uiManager.ShowMarketUi(true);
        marketScene.SetActive(true);
		marketScene.GetComponent<AudioSource> ().Play ();
		wifiScene.GetComponent<AudioSource> ().Stop ();
    }

    private void SwitchToForestView()
    {
        uiManager.ShowForestUi(true);
        forestScene.SetActive(true);
		marketScene.GetComponent<AudioSource> ().Stop ();
		wifiScene.GetComponent<AudioSource> ().Stop ();
    }

    private void SwitchToCabinView()
    {
        uiManager.ShowCabinUi(true);
        cabinScene.SetActive(true);
		marketScene.GetComponent<AudioSource> ().Stop ();
		wifiScene.GetComponent<AudioSource> ().Stop ();
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
