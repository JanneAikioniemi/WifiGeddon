using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinUI : MonoBehaviour {
	public GameObject EndGamePanel;
	public Image background;
	// Use this for initialization
	void Start () {
		
	}
	public void WinGame ()
	{
		EndGamePanel.SetActive (true);
	}
	public void NewGame ()
	{
		SceneManager.LoadScene(0);
	}
}
