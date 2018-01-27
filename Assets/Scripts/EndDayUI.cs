using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndDayUI : MonoBehaviour {
	public GameObject EndDayPanel;
	public GameObject EndGamePanel;
	public Image background;
	// Use this for initialization
	void Start () {
		background.canvasRenderer.SetAlpha (0);
	}
	
	// Update is called once per frame
	public IEnumerator Fade () {			
		background.CrossFadeAlpha (1.0f, 5.0f, true);
		yield return new WaitForSeconds (1.0f);

		Debug.Log (ResourceManager.Instance.daysLeft);
		if (ResourceManager.Instance.daysLeft > 0) {
			EndDayPanel.SetActive (true);
			EndGamePanel.SetActive (false);
			ResourceManager.Instance.daysLeft--;
		}
		else {
			EndDayPanel.SetActive (false);
			EndGamePanel.SetActive(true);
		}
	}
	public void EndGame ()
	{
		SceneManager.LoadScene(0);
	}
}
