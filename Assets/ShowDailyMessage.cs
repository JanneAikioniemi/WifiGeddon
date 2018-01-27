using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowDailyMessage : MonoBehaviour {
	public GameObject CabinEventUI;
	public Text dailyEventText;
	public void ShowDailyMessageDialog()
	{
		RandomEvent re = GameObject.Find ("App").GetComponent<RandomEventHandler> ().GetRandomEvent ();
		dailyEventText.text = re.descriptionText;
		switch (re.effect) {
			case Effect.loseTime: 
				ResourceManager.Instance.TimeLeftForRound -= re.value;
				break;
			case Effect.loseMoney: 
				if (ResourceManager.Instance.CurrentMoney < re.value)
					ResourceManager.Instance.CurrentMoney = 0;
				else
					ResourceManager.Instance.CurrentMoney -= re.value;
				break;
		case Effect.loseFood:
			if (ResourceManager.Instance.GetCurrentFood () < re.value)
				ResourceManager.Instance.RemoveAllFood ();
			else
				ResourceManager.Instance.RemoveAllFood();
				break;
		case Effect.loseBeer:
			if (ResourceManager.Instance.GetCurrentBeer () < re.value)
				ResourceManager.Instance.RemoveAllBooze ();
			else
				ResourceManager.Instance.RemoveBooze (re.value);
			break;

		case Effect.getMoney:
			if (ResourceManager.Instance.CurrentMoney < re.value)
				ResourceManager.Instance.CurrentMoney = 0;
			else
				ResourceManager.Instance.CurrentMoney -= re.value;
			break;
		}


		CabinEventUI.SetActive (true);
	}
}
