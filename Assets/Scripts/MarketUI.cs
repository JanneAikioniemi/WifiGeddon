using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketUI : MonoBehaviour
{
    [SerializeField] private KMarketHandler kMarket;
    [SerializeField] private RectTransform kRauta;
    [SerializeField] private RectTransform alko;

    void Start()
    {
        HideAll();
    }

    public void ShowKMarket()
    {
        HideAll();
        kMarket.gameObject.SetActive(true);
    }

    public void ShowKRauta()
    {
        HideAll();
        kRauta.gameObject.SetActive(true);
    }

    public void ShowAlko()
    {
        HideAll();
        alko.gameObject.SetActive(true);
    }

    public void HideAll()
    {
        kMarket.gameObject.SetActive(false);
        kRauta.gameObject.SetActive(false);
        alko.gameObject.SetActive(false);
    }
}
