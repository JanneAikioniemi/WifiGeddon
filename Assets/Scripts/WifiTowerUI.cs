using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WifiTowerUI : MonoBehaviour
{
    public Transform Popup;
	public Button[] sabotageButtons;
    public bool FenceBroken = false;
	public AudioClip[] tyonAanet;
	public int audioIndex = 0;
    void Start()
    {
    }

    void Update()
    {
		if (GetComponent<AudioSource> ().enabled && !GetComponent<AudioSource> ().isPlaying) {
			GetComponent<AudioSource> ().clip = tyonAanet [audioIndex];
			GetComponent<AudioSource> ().Play ();

			if (audioIndex < tyonAanet.Length-1)
				audioIndex++;					
		}			
    }
	public void ResetUI()
	{
		Popup.gameObject.SetActive (false);
		foreach (Button but in sabotageButtons) {
			but.interactable = true;
		}
	}
    public void BreakFence()
    {
        if (HasBoltCutter())
        {
            FenceBroken = true;
        }
        else
        {
			ShowPopup(Strings.NO_TOOLS);
        }

    }

    private bool HasBoltCutter()
    {
        return ResourceManager.Instance.HasSpecialItem(SpecialItemType.BoltCutter);
    }

	public void ShowPopup(string text)
    {
        StartCoroutine(WaitPopup(text));
    }

	private IEnumerator WaitPopup(string text)
    {
        Popup.GetComponentInChildren<Text>().text = text;
        Popup.gameObject.SetActive(true);
        yield return new WaitForSeconds(3.5f);
        Popup.gameObject.SetActive(false);
    }
}
