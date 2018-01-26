using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMoveToForest : MenuAction
{
    public override void Act()
    {
        base.Act();
        GameManager.Instance.SwitchView(ViewType.Forest);
    }
}
