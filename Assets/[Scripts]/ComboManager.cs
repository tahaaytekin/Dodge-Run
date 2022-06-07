using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class ComboManager : MonoBehaviour
{
    public TextMeshProUGUI text;
    public static ComboManager instance;
    public void Awake() => instance = this;

    public int comboCount;
    private int lastCount;
    public float time;

    public void Start()
    {
        InvokeRepeating(nameof(ResetCombo), 3.0f, time);
    }
    public void ResetCombo()
    {
        if (lastCount == comboCount)
        {
            comboCount = 0;
            Color color = text.color;
            color.a = 0;
            text.DOColor(color, 0.3f);
        }
        else
        {
            lastCount = comboCount;
        }
    }
    public void PrintCombo()
    {
        if (comboCount != 0 && comboCount > 0)
        {
            text.gameObject.SetActive(true);
            text.gameObject.GetComponent<Animator>().enabled = true;
            if (text.color.a != 1)
            {
                Color color = text.color;
                color.a = 1;
                text.color = color;
            }
            text.text = comboCount.ToString() + "x" ;
        }
        else
        {
            text.gameObject.SetActive(false);
        }
    }
}
