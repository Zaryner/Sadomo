using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    private TMPro.TMP_Text text;
    private Image img;
    private int value;
    private int maxValue;

    void Awake()
    {
        text = GetComponentInChildren<TMPro.TMP_Text>();
        img = GetComponentInChildren<Image>();
    }
    void UpdateText()
    {
        text.text = value.ToString() + " / " + maxValue.ToString();
    }
    void UpdateFilling()
    {
        img.fillAmount = (float)(value) / maxValue;
    }
    public void ChangeValueTo(int x)
    {
        value = x;
        UpdateText();
        UpdateFilling();
    }
    public void ChangeMaxValueTo(int x)
    {
        maxValue = x;
        UpdateText();
        UpdateFilling();
    }
    public void AddValue(int x)
    {
        value += x;
        UpdateText();
        UpdateFilling();
    }
    public void AddMaxValue(int x)
    {
        maxValue += x;
        UpdateText();
        UpdateFilling();
    }
}
