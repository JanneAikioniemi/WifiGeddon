using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WifiTowerUI : MonoBehaviour
{
    public Transform Popup;
    public bool FenceBroken = false;

    void Start()
    {
    }

    void Update()
    {

    }

    public void BreakFence()
    {
        if (HasBoltCutter())
        {
            FenceBroken = true;
        }
        else
        {
            ShowPopup();
        }

    }

    private bool HasBoltCutter()
    {
        return ResourceManager.Instance.HasSpecialItem(SpecialItemType.BoltCutter);
    }

    private void ShowPopup()
    {
        StartCoroutine(WaitPopup());
    }

    private IEnumerator WaitPopup()
    {
        Popup.GetComponentInChildren<Text>().text = Strings.NO_TOOLS;
        Popup.gameObject.SetActive(true);
        yield return new WaitForSeconds(3.5f);
        Popup.gameObject.SetActive(false);
    }
}
