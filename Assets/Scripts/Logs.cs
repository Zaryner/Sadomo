using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Logs : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text tmpText;
    private int counts = 0;

    public static string ListToString<T>(List<T> l)
    {
        string s = "[ ";
        for (int i = 0; i < l.Count; i++)
        {
            s += l[i].ToString() + ((i < l.Count - 1) ? ", " : " ");
        }
        s += "]";
        return s;
    }
    public void AddLog(string s)
    {
        tmpText.text += s;
    }
    public void SetLog(string s)
    {
        tmpText.text = s;
    }
    public void ShowLog()
    {
        this.gameObject.SetActive(true);
    }
    public void HideLog()
    {
        this.gameObject.SetActive(false);
    }
    public IEnumerator HideLog(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        if (counts <= 1)
        {
            counts--;
            this.gameObject.SetActive(false);
        }
        else
        {
            counts--;
        }

    }
    public void SetAndShowLog(string s, int seconds)
    {
        this.gameObject.SetActive(true);
        SetLog(s);
        counts++;
        StartCoroutine(HideLog(seconds));

    }
    public void AddAndShowLog(string s, int seconds)
    {
        this.gameObject.SetActive(true);
        AddLog(s);
        counts++;
        StartCoroutine(HideLog(seconds));

    }
}
