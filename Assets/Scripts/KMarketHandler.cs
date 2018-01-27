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
        int random = Random.Range(1, 10);

        for (int i = 0; i < random; i++)
        {
            var obj = Instantiate(GameManager.Instance.BuyButtonPrefab);
            obj.transform.SetParent(ContentRoot, false);
            obj.name = "Buy_" + i;
            obj.GetComponent<ActionBuyItem>().SetItem(ItemDB.Instance.GetFoodItems()[0]);
        }
    }
}
