using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionDrinkLiquor : MenuAction {
	public override void Act()
	{
		base.Act ();
		if (ResourceManager.Instance.CurrentLiquor > 0) {
			ResourceManager.Instance.CurrentLiquor--;
			ResourceManager.Instance.hangoverValue = 2;
		}
	}
}

