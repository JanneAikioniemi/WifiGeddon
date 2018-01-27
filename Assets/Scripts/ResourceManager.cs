using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    private static ResourceManager _instance;
    public static ResourceManager Instance
    {
        get { return _instance ?? (_instance = new ResourceManager()); }
    }
	public int daysLeft = 7;
    public float CurrentMoney = 300;
    public float CurrentWood = 100;
    public float TimeLeftForRound = 100;
    private List<Item> CurrentItems = new List<Item>();

    public void SetStartingCondition(float money, float timeLeft)
    {
        CurrentMoney = money;
        TimeLeftForRound = timeLeft;
    }

    public void ResetRound()
    {
        TimeLeftForRound = 100f;
    }

    public void AddToInventory(Item item)
    {
        CurrentItems.Add(item);

        Debug.Log("Current inventory: ");
        foreach (var it in CurrentItems)
        {
            Debug.Log(it.ItemType + " : " + it.DisplayName);
        }
    }

    public void RemoveFromInventory(string itemName)
    {
        int rmIndex = -1;
        for (var i = 0; i < CurrentItems.Count; i++)
        {
            if (CurrentItems[i].DisplayName.Equals(itemName))
            {
                rmIndex = i;
                break;
            }
        }

        if (rmIndex >= 0)
        {
            CurrentItems.RemoveAt(rmIndex);
        }
    }

    public void RemoveFood()
    {
        CurrentItems.RemoveAll(t => t.ItemType == ItemType.Food);
    }
}
