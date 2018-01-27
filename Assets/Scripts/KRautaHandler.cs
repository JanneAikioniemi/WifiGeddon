using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KRautaHandler : MonoBehaviour
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
        combinedList.AddRange(ItemDB.Instance.GetGeneralItems());

        int random = Random.Range(1, 100);
        if (random % 6 == 0)
        {
            var specItem = Random.Range(0, ItemDB.Instance.GetSpecialItems().Count);
            combinedList.Add(ItemDB.Instance.GetSpecialItems()[specItem]);
        }

        // Random amount of stuff in store
        for (int i = 0; i < combinedList.Count; i++)
        {
            var obj = Instantiate(GameManager.Instance.BuyButtonPrefab);
            obj.transform.SetParent(ContentRoot, false);
            obj.name = "Buy_" + combinedList[i].DisplayName;
            obj.GetComponent<ActionBuyItem>().SetItem(combinedList[i]);
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
