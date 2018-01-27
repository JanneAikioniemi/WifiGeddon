using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionBreakFence : MenuAction
{
    void Update()
    {
        if (GameManager.Instance.uiManager.WifiTowerUi.FenceBroken)
        {
            gameObject.SetActive(false);
        }
    }

    public override void Act()
    {
        base.Act();
        GameManager.Instance.uiManager.WifiTowerUi.BreakFence();
    }
}
