using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_ChopWood : PlayerAction
{
    public float PriceMin = 80;
    public float PriceMax = 185;

    public void EarnMoney()
    {
        ResourceManager.Instance.CurrentMoney += Random.Range(PriceMin, PriceMax);
    }

    public void ConsumeTime()
    {
        ResourceManager.Instance.TimeLeftForRound -= ActionPoint;
    }
}
