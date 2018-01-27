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

    public void RandomizeContent()
    {
        List<Item> combinedList = new List<Item>();
        combinedList.AddRange(ItemDB.Instance.GetFoodItems());
        combinedList.AddRange(ItemDB.Instance.GetBoozeItems());

        int random = Random.Range(1, 10);

        // Random amount of stuff in store
        for (int i = 0; i < random; i++)
        {
            if (combinedList.Count <= 0) break;

            int r = Random.Range(0, combinedList.Count);

            var obj = Instantiate(GameManager.Instance.BuyButtonPrefab);
            obj.transform.SetParent(ContentRoot, false);
            obj.name = "Buy_" + i;
            obj.GetComponent<ActionBuyItem>().SetItem(combinedList[r]);
            combinedList.RemoveAt(r);
        }
    }
}
