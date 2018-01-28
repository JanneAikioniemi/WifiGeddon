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

			if (GameManager.Instance.GetComponent<AudioSource> ().clip != GameManager.Instance.audioFiles [0]) {
				GameManager.Instance.GetComponent<AudioSource> ().clip = GameManager.Instance.audioFiles [0];
				GameManager.Instance.GetComponent<AudioSource> ().Play ();
			}
		}
	}
}

