using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBlowUpTheTower : MenuAction 
{
	public override void Act()
	{
		base.Act();
		if (ResourceManager.Instance.HasSpecialItem (SpecialItemType.Dynamite) &&
		    ResourceManager.Instance.fenceBroken) {
			GameManager.Instance.Win ();
		} else if (!ResourceManager.Instance.fenceBroken) {
			GameManager.Instance.uiManager.WifiTowerUi.ShowPopup (Strings.FENCE_NOT_BROKEN);
		}
		else
		{
			GameManager.Instance.uiManager.WifiTowerUi.ShowPopup (Strings.NO_TOOLS);
		}
	}
}