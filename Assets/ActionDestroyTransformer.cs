using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionDestroyTransformer : MenuAction 
{
	public override void Act()
	{
		base.Act();
		if (ResourceManager.Instance.HasSpecialItem(SpecialItemType.Crowbar) )
		{
			ResourceManager.Instance.daysLeft += 2;
			ResourceManager.Instance.TimeLeftForRound -= 50;
			this.GetComponent<Button> ().interactable = false;
		} 
		else 
		{
			GameManager.Instance.uiManager.WifiTowerUi.ShowPopup (Strings.NO_TOOLS);
		}
	}
}