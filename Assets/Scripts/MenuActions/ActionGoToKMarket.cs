using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionGoToKMarket : MenuAction
{
    public override void Act()
    {
        base.Act();
        GameManager.Instance.uiManager.MarketUi.ShowKMarket();
    }
}
