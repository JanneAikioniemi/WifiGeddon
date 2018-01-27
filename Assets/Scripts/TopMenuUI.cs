using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopMenuUI : MonoBehaviour
{
	public Text daysLeft;
	public Text CurrentMoney;

    void Update()
    {
		daysLeft.text = ResourceManager.Instance.daysLeft.ToString();
        CurrentMoney.text = string.Format("{0:0.00} €", ResourceManager.Instance.CurrentMoney);
    }
}
