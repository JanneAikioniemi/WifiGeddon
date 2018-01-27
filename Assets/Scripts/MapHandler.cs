using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapHandler : MonoBehaviour {
	public delegate void WoodChoppedAction();
	public static event WoodChoppedAction OnWoodChopped;

	void Update()
	{
		if ( Input.GetMouseButtonDown (0)){ 
			RaycastHit hit; 
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
			if ( Physics.Raycast (ray,out hit,100.0f)) {
				switch (hit.transform.tag)
				{
				case "FogOfWar":
					StartCoroutine (RevealTile (hit.transform));
					break;

				case "ForestTile":
					StartCoroutine (ForestTileClicked (hit.transform));
					break;
				case "EmptyTile":
					StartCoroutine (EmptyTileClicked (hit.transform));
					break;
				case "TowerTile":
					StartCoroutine (TowerTileClicked (hit.transform));
					break;
				}
			}
		}
	}
	IEnumerator RevealTile(Transform obj)
	{
		obj.gameObject.SetActive (false);
		yield return null;
	}
	IEnumerator ForestTileClicked(Transform obj)
	{
		Debug.Log ("Forest tile clicked");
		for (int i = 0; i < this.transform.childCount; i++) {			
			if (obj.GetChild (i).tag == "Wood" && obj.GetChild(i).gameObject.activeSelf)
			{					
				obj.GetChild (i).gameObject.SetActive (false);
				if (OnWoodChopped != null)
					OnWoodChopped ();
				break;
			}
		}
		yield return null;
	}
	IEnumerator EmptyTileClicked(Transform obj)
	{
		Debug.Log ("Empty tile clicked");
		yield return null;
	}
	IEnumerator TowerTileClicked(Transform obj)
	{
		Debug.Log ("Tower tile clicked");
		yield return null;
	}
}
