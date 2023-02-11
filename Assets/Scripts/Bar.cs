using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    private TMPro.TMP_Text text;
    private Image img;
    private int value;
    private int maxValue;
    private bool isHiden;

    void Awake()
    {
        text = GetComponentInChildren<TMPro.TMP_Text>();
        img = GetComponentInChildren<Image>();
        isHiden = false;
    }
    void UpdateText()
    {
        if (isHiden)
        {
            string hValue = "";
            for (int i = 0; i < (int)Mathf.Log10(value) + 1; i++)
            {
                hValue += "?";
            }
            string hMaxValue = "";
            for (int i = 0; i < (int)Mathf.Log10(maxValue) + 1; i++)
            {
                hMaxValue += "?";
            }
            text.text = hValue.ToString() + " / " + hMaxValue.ToString();
            return;
        }
        text.text = value.ToString() + " / " + maxValue.ToString();
    }
    void UpdateFilling()
    {
        if (isHiden) return;
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
    public void HideBarValues()
    {
        string hValue = "";
        for (int i = 0; i < (int)Mathf.Log10(value) + 1; i++)
        {
            hValue += "?";
        }
        string hMaxValue = "";
        for (int i = 0; i < (int)Mathf.Log10(maxValue) + 1; i++)
        {
            hMaxValue += "?";
        }
        text.text = hValue.ToString() + " / " + hMaxValue.ToString();
        isHiden = true;
        img.fillAmount = 0f;
    }
    public void UnhideBarValues()
    {
        isHiden = false;
        UpdateFilling();
        UpdateText();
    }

}
