using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ActionThreaten : MenuAction {

		public override void Act()
		{
			base.Act();
			ResourceManager.Instance.daysLeft++;
			ResourceManager.Instance.TimeLeftForRound -=50;
			this.GetComponent<Button> ().interactable = false;
		}
	}
