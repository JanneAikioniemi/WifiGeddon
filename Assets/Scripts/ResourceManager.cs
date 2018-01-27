using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        if (ItemExists(item))
        {
            var curItem = CurrentItems.First(i => i.DisplayName == item.DisplayName);
            curItem.OwnedItems++;
        }
        else
        {
            item.OwnedItems++;
            CurrentItems.Add(item);
        }



        Debug.Log("Current inventory: ");
        foreach (var it in CurrentItems)
        {
            Debug.Log(it.ItemType + " : " + it.DisplayName + " count: " + it.OwnedItems);
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

    private bool ItemExists(Item item)
    {
        foreach (var i in CurrentItems)
        {
            if (i.DisplayName == item.DisplayName)
            {
                return true;
            }
        }

        return false;
    }

    public void RemoveFood()
    {
        CurrentItems.RemoveAll(t => t.ItemType == ItemType.Food);
    }

    public bool HasSpecialItem(SpecialItemType type)
    {
        foreach (var i in ItemDB.Instance.GetSpecialItems())
        {
            if (i.Special == type)
            {
                return i.IsOwned;
            }
        }

        return false;
    }
}
