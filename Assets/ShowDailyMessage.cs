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
		ResourceManager.Instance.dayCounter++;

		if (ResourceManager.Instance.dayCounter % 6 == 0 && ResourceManager.Instance.CurrentLiquor>0) {
			dailyEventText.text += "\n\nInstantly when you wake up, you realize that it is Friday and chug a bottle of liquor for the occasion.\nIt's Friday and you don't have your Friday bottle. You contemplate life for six hours.";
			ResourceManager.Instance.CurrentLiquor = 0;
			ResourceManager.Instance.TimeLeftForRound -= 30;
		}
		if (ResourceManager.Instance.dayCounter % 6 == 0 && ResourceManager.Instance.CurrentBeer>0) {
			dailyEventText.text += "\n\nYour friend pays you a visit before going off to work. The damn drunk empties your beer reserves before he abruptly leaves for work, grumbling something about being late.\nYour friend pays you a visit. You heat up cold coffee from yesterday and exchange couple boring notions of todays weather with him.";
			ResourceManager.Instance.CurrentBeer = 0;
		}
		else if (ResourceManager.Instance.hangoverValue == 1) {
			dailyEventText.text += "\n\nYou wake up covered in your own drool. Your sleeping position has been less than ideal. Morning tasks seem to take forever as you wait caffeine to kick in. You lose two hours of time.";
			ResourceManager.Instance.TimeLeftForRound -= 15;
		}
		else if(ResourceManager.Instance.hangoverValue == 2) {
			dailyEventText.text += "\n\nYou have slept like a baby - Covered in your own vomit and shit. It takes four hours for you to hug porcelain plumbing fixture and throw your sheets to burnable trash.";
			ResourceManager.Instance.TimeLeftForRound -= 30;

		}

		if (ResourceManager.Instance.CurrentFood == 0) {
			dailyEventText.text += "\n\nYou wake up to a crippling hunger. You gobble up something resembling of a food that is intended for human beings and go back to bed to sleep for a few more hours.";
			ResourceManager.Instance.TimeLeftForRound -= 15;
		} else
			ResourceManager.Instance.CurrentFood--;
		
		/*else if( ResourceManager.Instance.hangoverValue == 2) {
			dailyEventText.text += "\n\nTo your surprise, you are visited by the local police chief. He talks about the events that you are completely oblivious about and takes you to a police station for questioning for the whole day.";
			ResourceManager.Instance.TimeLeftForRound -= 30;
		*/
		CabinEventUI.SetActive (true);
	}
}
