using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBuyItem : MenuAction
{
    private Item item;
    [SerializeField]
    private GameObject popupScreen;

    public override void Act()
    {
        base.Act();
        Buy();
    }

    void Update()
    {
        if (item == null) return;

        m_button.image.color = CanAfford() ? Color.white : Color.red;
    }

    public void SetItem(Item i)
    {
        item = i;

        m_button.transform.GetComponentInChildren<Text>().text = string.Format("{0} - {1:0}", item.DisplayName, item.Price);
    }

    public bool CanAfford()
    {
        return item.Price < ResourceManager.Instance.CurrentMoney;
    }

    private void Buy()
    {
        if (!CanAfford())
        {
            ShowPopup();
            return;
        }
        // Reduce price from current cash
        ResourceManager.Instance.CurrentMoney -= item.Price;

		if (item.GetType () == typeof(SpecialItem)) {
			var i = item as SpecialItem;
			i.IsOwned = true;
		}
        // Add item to inventory
        ResourceManager.Instance.AddToInventory(item);
    }

    private void ShowPopup()
    {
        StartCoroutine(PopupTimer());
    }

    private IEnumerator PopupTimer()
    {
        popupScreen.SetActive(true);
        yield return new WaitForSeconds(3.5f);
        popupScreen.SetActive(false);
    }
}
