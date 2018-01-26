using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuAction : MonoBehaviour
{
    protected Button m_button;

    void Awake()
    {
        m_button = GetComponent<Button>();
        m_button.onClick.AddListener(Act);
    }

    public virtual void Act() { }
}
