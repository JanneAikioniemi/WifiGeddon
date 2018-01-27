using System.Collections.Generic;
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
        combinedList.AddRange(ItemDB.Instance.GetBoozeItems());

        // min and max items
        int maximum = combinedList.Count;
        int minimum = combinedList.Count / 3;

        int randomAmountOfItems = Random.Range(minimum, maximum);

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
}
