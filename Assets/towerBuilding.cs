using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerBuilding : MonoBehaviour {
	public GameObject tower1;
	public GameObject tower2;
	public GameObject tower3;
	public GameObject tower4;
	public GameObject tower5;
	public GameObject tower6;
	public GameObject tower7;
	public GameObject tower8;

	// Update is called once per frame
	void Update () {
		int daysLeft = ResourceManager.Instance.daysLeft;
		switch (daysLeft) {
		case 0:
			tower1.SetActive (true);
			tower2.SetActive (true);
			tower3.SetActive (true);
			tower4.SetActive (true);
			tower5.SetActive (true);
			tower6.SetActive (true);
			tower7.SetActive (true);
			tower8.SetActive (true);
			break;
		case 1:
			tower1.SetActive (true);
			tower2.SetActive (true);
			tower3.SetActive (true);
			tower4.SetActive (true);
			tower5.SetActive (true);
			tower6.SetActive (true);
			tower7.SetActive (true);
			tower8.SetActive (false);
			break;
		case 2:
			tower1.SetActive (true);
			tower2.SetActive (true);
			tower3.SetActive (true);
			tower4.SetActive (true);
			tower5.SetActive (true);
			tower6.SetActive (true);
			tower7.SetActive (false);
			tower8.SetActive (false);
			break;		
		case 3:
			tower1.SetActive (true);
			tower2.SetActive (true);
			tower3.SetActive (true);
			tower4.SetActive (true);
			tower5.SetActive (true);
			tower6.SetActive (false);
			tower7.SetActive (false);
			tower8.SetActive (false);
			break;
		case 4:
			tower1.SetActive (true);
			tower2.SetActive (true);
			tower3.SetActive (true);
			tower4.SetActive (true);
			tower5.SetActive (false);
			tower6.SetActive (false);
			tower7.SetActive (false);
			tower8.SetActive (false);
			break;
		case 5:
			tower1.SetActive (true);
			tower2.SetActive (true);
			tower3.SetActive (true);
			tower4.SetActive (false);
			tower5.SetActive (false);
			tower6.SetActive (false);
			tower7.SetActive (false);
			tower8.SetActive (false);
			break;
		case 6:
			tower1.SetActive (true);
			tower2.SetActive (true);
			tower3.SetActive (false);
			tower4.SetActive (false);
			tower5.SetActive (false);
			tower6.SetActive (false);
			tower7.SetActive (false);
			tower8.SetActive (false);
			break;
		default:
			tower1.SetActive (true);
			tower2.SetActive (false);
			tower3.SetActive (false);
			tower4.SetActive (false);
			tower5.SetActive (false);
			tower6.SetActive (false);
			tower7.SetActive (false);
			tower8.SetActive (false);
			break;
		}
	}
}
