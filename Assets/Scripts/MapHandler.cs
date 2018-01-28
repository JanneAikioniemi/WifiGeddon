using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapHandler : MonoBehaviour
{
    public delegate void WoodChoppedAction();
    public static event WoodChoppedAction OnWoodChopped;
    public EventSystem _eventSystem;
    public float timeSpendOnSearch = 5f;
    public float timeSpendOnChopping = 10f;
    public int moneyFromChopping = 100;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ResourceManager.Instance.TimeLeftForRound > 0 && !_eventSystem.IsPointerOverGameObject())
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                switch (hit.transform.tag)
                {
                    case "FogOfWar":
                        StartCoroutine(RevealTile(hit.transform));
                        break;
                    case "ForestTile":
                        StartCoroutine(ForestTileClicked(hit.transform));
                        break;
                    case "EmptyTile":
                        StartCoroutine(EmptyTileClicked(hit.transform));
                        break;
                    case "TowerTile":
                        StartCoroutine(TowerTileClicked(hit.transform));
                        break;
                }
            }
        }
    }
    IEnumerator RevealTile(Transform obj)
    {
		if(ResourceManager.Instance.HasSkis())
			ResourceManager.Instance.TimeLeftForRound -= timeSpendOnSearch/2;
		else
			ResourceManager.Instance.TimeLeftForRound -= timeSpendOnSearch;
        obj.gameObject.SetActive(false);
        yield return null;
    }
    IEnumerator ForestTileClicked(Transform obj)
    {
        //Debug.Log ("Forest tile clicked");
        for (int i = 0; i < obj.childCount; i++)
        {
            if (obj.GetChild(i).tag == "Wood" && obj.GetChild(i).gameObject.activeSelf)
            {
                obj.GetChild(i).gameObject.SetActive(false);
                /*if (OnWoodChopped != null)
					OnWoodChopped ();
					*/
				if (ResourceManager.Instance.hangoverValue == 0) {
					ResourceManager.Instance.CurrentMoney += moneyFromChopping;
					ResourceManager.Instance.TimeLeftForRound -= timeSpendOnChopping;
				} else if (ResourceManager.Instance.hangoverValue == 1) {
					ResourceManager.Instance.CurrentMoney += moneyFromChopping*1.5f;
					ResourceManager.Instance.TimeLeftForRound -= timeSpendOnChopping;
				}
				else if (ResourceManager.Instance.hangoverValue == 2) {
					ResourceManager.Instance.CurrentMoney += moneyFromChopping*2;
					ResourceManager.Instance.TimeLeftForRound -= timeSpendOnChopping;
				}
                break;
            }
        }
        yield return null;
    }
    IEnumerator EmptyTileClicked(Transform obj)
    {
        Debug.Log("Empty tile clicked");
        yield return null;
    }
    IEnumerator TowerTileClicked(Transform obj)
    {
        GameManager.Instance.SwitchView(ViewType.WifiTower);
        yield return null;
    }
}
