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
	public float CurrentFood = 0;
	public float CurrentBeer = 0;
	public float CurrentLiquor = 0;
    public float TimeLeftForRound = 100;
	public bool fenceBroken = false;
    private List<Item> CurrentItems = new List<Item>();
	public Vector2 towerLocation;
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
			curItem.OwnedItems ++;
        }
        else
        {        
            CurrentItems.Add(item);
        }



        Debug.Log("Current inventory: ");
        foreach (var it in CurrentItems)
        {
            Debug.Log(it.ItemType + " : " + it.DisplayName + " count: " + it.OwnedItems);
			if (it.ItemType == ItemType.Booze) {
				ResourceManager.Instance.CurrentBeer = it.OwnedItems;
			}
			if (it.ItemType == ItemType.Liquor) {
				ResourceManager.Instance.CurrentLiquor = it.OwnedItems;
			}
			if (it.ItemType == ItemType.Food) {
				ResourceManager.Instance.CurrentFood = it.OwnedItems;
			}
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

    public void RemoveAllFood()
    {
        CurrentItems.RemoveAll(t => t.ItemType == ItemType.Food);
    }
	public void RemoveFood(int amount)
	{
		
	}
	public void RemoveAllBooze()
	{
		CurrentItems.RemoveAll(t => t.ItemType == ItemType.Booze);
	}
	public void RemoveBooze(int amount)
	{

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
	public int GetCurrentFood()
	{
		int c = 0;
		foreach (var i in ItemDB.Instance.GetFoodItems())
		{
			if (i.ItemType == ItemType.Food)
			{
				c = c + (i.OwnedItems == 0 ? 1 : i.OwnedItems);
			}
		}

		return c;
	}
	public int GetCurrentBeer()
	{
		int c = 0;
		foreach (var i in ItemDB.Instance.GetBeerItems())
		{
			if (i.ItemType == ItemType.Booze)
			{
				c++;
			}
		}

		return c;
	}
	public int GetCurrentLiquor()
	{
		int c = 0;
		foreach (var i in ItemDB.Instance.GetLiquorItems())
		{
			if (i.ItemType == ItemType.Liquor)
			{
				c++;
			}
		}

		return c;
	}
}
