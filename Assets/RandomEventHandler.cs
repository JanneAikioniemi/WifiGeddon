using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEventHandler : MonoBehaviour {
	List<RandomEvent> randomEventList;
	int randomEventIndex = 0;
	public enum Effect
	{
		loseTime,
		loseMoney,
		loseItem,
		getMoney, 
		getItem
	}
	public class RandomEvent {
		public string descriptionText;
		public Effect effect;
		public int value;

		public RandomEvent(string dt, Effect e, int a)
		{
			this.descriptionText = dt;
			this.effect = e;
			this.value = a;
		}
	}
	void Start()
	{
		randomEventList = new List<RandomEvent>();
		GenerateRandomEventList ();
		RandomizeList ();
	}
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Space)) {
			Debug.Log (randomEventList [randomEventIndex].descriptionText + ": " + randomEventList [randomEventIndex].effect + ", " + randomEventList [randomEventIndex].value);
			if (randomEventIndex < randomEventList.Count-1)
				randomEventIndex++;
			else {
				randomEventIndex = 0;
				RandomizeList ();
			}
		}
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
	{
		AddRandomEventToList("Krapula", Effect.loseTime, 10);
		AddRandomEventToList("Oli pakko hakea loipparia kaupasta", Effect.loseMoney, 100);
		AddRandomEventToList("Hukkasit kirveen", Effect.loseItem, 1);
		AddRandomEventToList("Kaveri makso velat", Effect.getMoney, 50);
		AddRandomEventToList("Löysit sukset", Effect.getItem, 2);
		AddRandomEventToList("Herätyskello unohtui", Effect.loseTime, 5);
		AddRandomEventToList("Hukkasit rahasi", Effect.loseMoney, 30);
		AddRandomEventToList("Hukkasit suksesi", Effect.loseItem, 2);
		AddRandomEventToList("Löysit rahhaa", Effect.getMoney, 25);
		AddRandomEventToList("Löysit putkisakset", Effect.getItem, 3);
	}
	void AddRandomEventToList (string text, Effect effect, int value)
	{
		RandomEvent re = new RandomEvent (text, effect, value);
		randomEventList.Add(re);
	}
}
