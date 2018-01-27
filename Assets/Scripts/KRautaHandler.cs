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

        // Random amount of stuff in store
        for (int i = 0; i < combinedList.Count; i++)
        {
            var obj = Instantiate(GameManager.Instance.BuyButtonPrefab);
            obj.transform.SetParent(ContentRoot, false);
            obj.name = "Buy_" + combinedList[i].DisplayName;
            obj.GetComponent<ActionBuyItem>().SetItem(combinedList[i]);
        }
    }
}
