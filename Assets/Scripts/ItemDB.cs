using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemDB : MonoBehaviour
{
    public static ItemDB Instance;

    [SerializeField] private List<Item> foodItems;
    [SerializeField] private List<Item> generalItems;
    [SerializeField] private List<Item> boozeItems;
    [SerializeField] private List<SpecialItem> specialItems;

    void Awake()
    {
        if (Instance != null) return;
        Instance = this;
    }

    public List<Item> GetFoodItems()
    {
        return foodItems;
    }

    public List<Item> GetBoozeItems()
    {
        return boozeItems;
    }

    public List<Item> GetGeneralItems()
    {
        return generalItems;
    }

    public List<SpecialItem> GetSpecialItems()
    {
        return specialItems;
    }
}

public enum ItemType
{
    Food,
    Booze,
    General,
    Special
}

public enum SpecialItemType
{
    BoltCutter,
    Crowbar,
    Dynamite,
    TinFoil,
	Axe
}
public enum Effect
{
	nothing,
	loseTime,
	loseMoney,
	loseFood,
	loseBeer,
	loseItem,
	getMoney, 
	injure,
	getItem
}

[Serializable]
public class RandomEvent {
	public string descriptionText;
	public Effect effect;
	public int value;

	public RandomEvent(string dt, Effect e, int a)
	{
		this.descriptionText = dt;
		this.effect = e;
		this.value = a;
	}
}

[Serializable]
public class Item
{
    [SerializeField]
    public ItemType ItemType;
    [SerializeField]
    public string DisplayName;
    [SerializeField]
    public float Price;
    [SerializeField]
    public int OwnedItems;

    public Item(ItemType type, string name, float price)
    {
        ItemType = type;
        DisplayName = name;
        Price = price;
    }
}

[Serializable]
public class SpecialItem : Item
{
    [SerializeField]
    public SpecialItemType Special;
    [SerializeField]
    public bool IsOwned;

    public SpecialItem(ItemType type, string name, float price) : base(type, name, price)
    {
        type = ItemType.Special;
        DisplayName = name;
        Price = price;
    }
}