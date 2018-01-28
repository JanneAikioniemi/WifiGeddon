using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionBreakFence : MenuAction
{
	public GameObject fencePart;
    void Update()
    {
        if (GameManager.Instance.uiManager.WifiTowerUi.FenceBroken)
        {
			fencePart.SetActive (false);
            gameObject.SetActive(false);
			ResourceManager.Instance.fenceBroken = true;
        }
    }

    public override void Act()
    {
        base.Act();
        GameManager.Instance.uiManager.WifiTowerUi.BreakFence();
    }
}
