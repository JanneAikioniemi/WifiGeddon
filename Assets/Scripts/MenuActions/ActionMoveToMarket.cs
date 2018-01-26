using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMoveToMarket : MenuAction
{
    public override void Act()
    {
        base.Act();
        GameManager.Instance.SwitchView(ViewType.Market);
    }
}
