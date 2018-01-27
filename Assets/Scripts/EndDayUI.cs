using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndDayUI : MonoBehaviour {
	public GameObject EndDayPanel;
	public Image background;
	// Use this for initialization
	void Start () {
		background.canvasRenderer.SetAlpha (0);
	}
	
	// Update is called once per frame
	public IEnumerator Fade () {			
		background.CrossFadeAlpha (1.0f, 5.0f, true);
		yield return new WaitForSeconds (1.0f);
		EndDayPanel.SetActive (true);
		ResourceManager.Instance.daysLeft--;
	}
}
