using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionDrinkBeer : MenuAction {
	public override void Act()
	{
		base.Act ();
		if (ResourceManager.Instance.CurrentBeer > 0) {
			ResourceManager.Instance.CurrentBeer--;
			if (ResourceManager.Instance.hangoverValue == 0)
				ResourceManager.Instance.hangoverValue = 1;

			if (GameManager.Instance.GetComponent<AudioSource> ().clip != GameManager.Instance.audioFiles [0]) {
				GameManager.Instance.GetComponent<AudioSource> ().clip = GameManager.Instance.audioFiles [0];
				GameManager.Instance.GetComponent<AudioSource> ().Play ();
			}
		}
	}

}

