using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionStealTools : MenuAction 
{
	public override void Act()
	{
		base.Act();
		if (ResourceManager.Instance.fenceBroken == true) {
			ResourceManager.Instance.daysLeft += 1;
			ResourceManager.Instance.TimeLeftForRound -= 25;
			this.GetComponent<Button> ().interactable = false;
		} else {
			GameManager.Instance.uiManager.WifiTowerUi.ShowPopup (Strings.FENCE_NOT_BROKEN);
		}
	}
}