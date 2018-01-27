using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionGoToKRauta : MenuAction 
{
    public override void Act()
    {
        base.Act();
        GameManager.Instance.uiManager.MarketUi.ShowKRauta();
    }
}
