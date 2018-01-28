using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEventHandler : MonoBehaviour {
	List<RandomEvent> randomEventList;
	int randomEventIndex = 0;


	void Start()
	{
		randomEventList = new List<RandomEvent>();
		GenerateRandomEventList ();
		RandomizeList ();
	}
	void Update()
	{
		/*
		if (Input.GetKeyDown (KeyCode.Space)) {
			Debug.Log (randomEventList [randomEventIndex].descriptionText + ": " + randomEventList [randomEventIndex].effect + ", " + randomEventList [randomEventIndex].value);
			if (randomEventIndex < randomEventList.Count-1)
				randomEventIndex++;
			else {
				randomEventIndex = 0;
				RandomizeList ();
			}
		}
		*/
	}
	public RandomEvent GetRandomEvent (){
		//Debug.Log (randomEventList [randomEventIndex].descriptionText + ": " + randomEventList [randomEventIndex].effect + ", " + randomEventList [randomEventIndex].value);
		RandomEvent currentEvent = randomEventList[randomEventIndex];
		if (ResourceManager.Instance.daysLeft == 5) {
			string direction;
			if(ResourceManager.Instance.towerLocation.x <5)
				direction = "Western";
			else				
				direction = "Eastern";
			currentEvent.descriptionText += "\n\nYou heard rumors from postman that he spotted Tele Norland van in the " + direction + " part of the forest.";
		}
		if (ResourceManager.Instance.daysLeft == 3) {
			string direction;
			if(ResourceManager.Instance.towerLocation.y < 5)
				direction = "Southern";
			else				
				direction = "Northern";
			currentEvent.descriptionText += "\n\nYou heard rumors from postman that he spotted Tele Norland van in the " + direction + " part of the forest.";
		}
		if (randomEventIndex < randomEventList.Count-1)
			randomEventIndex++;
		else {
			randomEventIndex = 0;
			RandomizeList ();
		}
		return currentEvent;
	}
	void RandomizeList()
	{
		for (int i = 0; i < randomEventList.Count; i++) {
			RandomEvent temp = randomEventList[i];
			int randomIndex = Random.Range(i, randomEventList.Count);
			randomEventList[i] = randomEventList[randomIndex];
			randomEventList[randomIndex] = temp;
		}
	}
	void GenerateRandomEventList()
	{	//AXE IS LOST ITEM 1
		AddRandomEventToList("You wake up delirious and your memory is hazy. You remember shouting to a squirrel and you notice that you have tried to make more firewood. During your morning practices, you notice that your axe is blunt, you had to sharpen it.", Effect.loseTime, 10);
		AddRandomEventToList("You wake up with your mouth half full of food. Some remains of hazy memories return to you about feeding birds with your food rations that seem like a dream. When eating your morning cereals, you notice that couple days worth of food is missing.", Effect.loseFood, 2);
		AddRandomEventToList("You wake up covered in blood, WTF?", Effect.loseTime, 10);
		AddRandomEventToList("During your morning activities, your good friend stops by to pay you his loan that you have already forgotten. You gain 20$.", Effect.getMoney, 20);
		AddRandomEventToList("You get mail from Tele Norland. It's an invoice for a cell phone plan. You rip it to shreds.", Effect.nothing, 0);
		AddRandomEventToList("Your morning was uneventful", Effect.nothing, 0);
		AddRandomEventToList("You shaved your beard and ate breakfast.", Effect.nothing, 0);
		AddRandomEventToList("You see a wood grouse looking for food near your barn. You try to kill it by throwing a kitchen knife towards it, but the laughable attempt just ends up raising your blood pressure.", Effect.loseTime, 5);
		AddRandomEventToList("Your friend pays you a visit before going off to work. The damn drunk empties your beer reserves before he abruptly leaves for work, grumbling something about being late.", Effect.loseBeer, 100);
		AddRandomEventToList("Your friend pays you a visit. You heat up cold coffee from yesterday and exchange couple boring notions of todays weather with him.", Effect.nothing, 0);
		AddRandomEventToList("You have hurt your hand as a totally unexpected result of trying to act like a functionin alcoholic. It takes four hours for you to extract your morning coffee.", Effect.loseTime, 25);
	}
	void AddRandomEventToList (string text, Effect effect, int value)
	{
		RandomEvent re = new RandomEvent (text, effect, value);
		randomEventList.Add(re);
	}
}
