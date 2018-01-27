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

	void Update()
	{						
		float imageFillAmount = ResourceManager.Instance.TimeLeftForRound / clockMaxValue;
		fillImage.fillAmount = 1f-imageFillAmount;

		if (clockCurrentValue >= clockMaxValue) {
			if(OnOutOfTime!=null)
				OnOutOfTime ();
		}
	}
}
