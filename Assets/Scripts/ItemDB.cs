using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemDB : MonoBehaviour
{
    public static ItemDB Instance;

    [SerializeField] private List<Item> foodItems;
    [SerializeField] private List<Item> generalItems;
    [SerializeField] private List<Item> sabotageItems;
    [SerializeField] private List<Item> weaponItems;

    void Awake()
    {
        if (Instance != null) return;
        Instance = this;
    }

    public List<Item> GetFoodItems()
    {
        return foodItems;
    }

    public List<Item> GetGeneralItems()
    {
        return generalItems;
    }

    public List<Item> GetSabotageItems()
    {
        return sabotageItems;
    }

    public List<Item> GetWeaponItems()
    {
        return weaponItems;
    }
}

public enum ItemType
{
    Food,
    General,
    Sabotage,
    Weapon
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

    public Item(ItemType type, string name, float price)
    {
        ItemType = type;
        DisplayName = name;
        Price = price;
    }
}

