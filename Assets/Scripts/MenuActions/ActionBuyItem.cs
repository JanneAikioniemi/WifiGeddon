using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBuyItem : MenuAction
{
    private Item item;

    public override void Act()
    {
        base.Act();
        Buy();
    }

    void Update()
    {
        if (item != null)
            CanAfford();
    }

    public void SetItem(Item i)
    {
        item = i;

        m_button.transform.GetComponentInChildren<Text>().text = item.DisplayName;
    }

    public void CanAfford()
    {
        if (item.Price > ResourceManager.Instance.CurrentMoney)
        {
            m_button.interactable = false;
            m_button.image.color = Color.red;
        }
        else
        {
            m_button.interactable = true;
            m_button.image.color = Color.white;
        }
    }

    private void Buy()
    {
        // Reduce price from current cash
        ResourceManager.Instance.CurrentMoney -= item.Price;

        // Add item to inventory

    }
}
