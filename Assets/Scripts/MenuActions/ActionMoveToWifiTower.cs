using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMoveToWifiTower : MenuAction 
{
    public override void Act()
    {
        base.Act();
        GameManager.Instance.SwitchView(ViewType.WifiTower);
    }
}
