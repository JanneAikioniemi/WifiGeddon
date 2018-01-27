using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockManager : MonoBehaviour {
	public delegate void OutOfTimeAction();
	public static event OutOfTimeAction OnOutOfTime;
	public Image fillImage;
	public float clockMaxValue = 100;
	private float clockCurrentValue = 0;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			TimeUse (10);
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			TimeUse (5);
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			TimeUse (1);
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			TimeUse (25);
		}
	}
	void TimeUse (int usedTime)
	{
		clockCurrentValue += usedTime;
		clockCurrentValue = Mathf.Clamp (clockCurrentValue, 0, clockMaxValue);
		Debug.Log (clockCurrentValue);
		float imageFillAmount = clockCurrentValue / clockMaxValue;
		fillImage.fillAmount = imageFillAmount;

		if (clockCurrentValue >= clockMaxValue) {
			if(OnOutOfTime!=null)
				OnOutOfTime ();
		}
	}
}
