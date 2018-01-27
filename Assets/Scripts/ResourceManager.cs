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

    public void SetStartingCondition(float money, float timeLeft)
    {
        CurrentMoney = money;
        TimeLeftForRound = timeLeft;
    }

    public void ResetRound(float amount)
    {
        TimeLeftForRound = 100f;
    }
}
