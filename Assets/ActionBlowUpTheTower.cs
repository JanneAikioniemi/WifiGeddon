using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBlowUpTheTower : MenuAction 
{
	public override void Act()
	{
		base.Act();
		if (ResourceManager.Instance.HasSpecialItem(SpecialItemType.Dynamite) )
		{
			GameManager.Instance.Win ();
		} 
		else 
		{
			GameManager.Instance.uiManager.WifiTowerUi.ShowPopup (Strings.NO_TOOLS);
		}
	}
}