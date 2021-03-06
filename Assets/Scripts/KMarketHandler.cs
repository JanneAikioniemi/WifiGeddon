﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KMarketHandler : MonoBehaviour
{
    public RectTransform ContentRoot;

    void Start()
    {
        RandomizeContent();
    }

    // TODO: should randomize once per day
    public void RandomizeContent()
    {
        List<Item> combinedList = new List<Item>();
        combinedList.AddRange(ItemDB.Instance.GetFoodItems());
        combinedList.AddRange(ItemDB.Instance.GetGeneralItems());
        combinedList.AddRange(ItemDB.Instance.GetBeerItems());
		combinedList.AddRange(ItemDB.Instance.GetLiquorItems());

        // min and max items
        int maximum = combinedList.Count;
        int minimum = combinedList.Count / 3;

        int randomAmountOfItems = Random.Range(minimum, maximum);
		int random = Random.Range(1, 100);
		if (random % ResourceManager.Instance.daysLeft >= 1)
		{
			var specItem = Random.Range(0, ItemDB.Instance.GetSpecialItems().Count);
			combinedList.Add(ItemDB.Instance.GetSpecialItems()[specItem]);
		}

        // Random amount of stuff in store
        for (int i = 0; i < randomAmountOfItems; i++)
        {
            if (combinedList.Count <= 0) break;

            // random item
            int r = Random.Range(0, combinedList.Count);
            var item = combinedList[r];

            var obj = Instantiate(GameManager.Instance.BuyButtonPrefab);
            obj.transform.SetParent(ContentRoot, false);
            obj.name = "Buy_" + item.DisplayName;
            obj.GetComponent<ActionBuyItem>().SetItem(combinedList[r]);
            combinedList.RemoveAt(r);
        }
    }

    private void RemoveItems()
    {
        foreach (Transform child in ContentRoot)
        {
            Destroy(child.gameObject);
        }
    }

    public void Refresh()
    {
        RemoveItems();
        RandomizeContent();
    }
}
