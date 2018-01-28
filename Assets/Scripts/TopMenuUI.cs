using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopMenuUI : MonoBehaviour
{
	public Text daysLeft;
	public Text CurrentMoney;
	public Text foodLeft;
	public Text beerLeft;
	public Text liquorLeft;

    void Update()
    {
		daysLeft.text = ResourceManager.Instance.daysLeft.ToString();
        CurrentMoney.text = string.Format("{0:0.00} €", ResourceManager.Instance.CurrentMoney);
		foodLeft.text = ResourceManager.Instance.CurrentFood.ToString();
		beerLeft.text = ResourceManager.Instance.CurrentBeer.ToString();
		liquorLeft.text = ResourceManager.Instance.CurrentLiquor.ToString();
    }
}
