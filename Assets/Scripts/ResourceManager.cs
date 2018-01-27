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

    public float CurrentMoney = 300;
    public float CurrentWood = 100;
    public float TimeLeftForRound = 100;

    public void ReduceMoney(float amount)
    {
        CurrentMoney -= amount;
    }

    public void IncreaseMoney(float amount)
    {
        CurrentMoney += amount;
    }

    public void ReduceWood(float amount)
    {
        CurrentWood -= amount;
    }

    public void IncreaseWood(float amount)
    {
        CurrentWood += amount;
    }

    public void ReduceTime(float amount)
    {
        TimeLeftForRound -= amount;
    }

    public void ResetRound(float amount)
    {
        TimeLeftForRound = 100f;
    }
}
