using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopMenu : MonoBehaviour
{
    public Text CurrentMoney;

    void Update()
    {
        CurrentMoney.text = string.Format("{0:0.00} €", ResourceManager.Instance.CurrentMoney);
    }
}
