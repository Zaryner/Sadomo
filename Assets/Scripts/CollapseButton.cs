using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollapseButton : MonoBehaviour
{
    private Button button;
    private Image img;
    [SerializeField] private GameObject plane;
    [SerializeField] private GameObject spellText;
    [SerializeField] private GameObject[] trail;
    private bool isActive;
    void Start()
    {
        button = GetComponent<Button>();
        img = GetComponent<Image>();
        isActive = true;
    }

    public void Click()
    {
        if (isActive) CollapsePanel();
        else ExpandPanel();
        isActive = !isActive;
    }

    void CollapsePanel()
    {
        for (int i = 0; i < trail.Length; i++)
        {
            trail[i].gameObject.SetActive(false);
        }
        plane.gameObject.SetActive(false);
        spellText.gameObject.SetActive(true);
        img.color = new Color32(207, 207, 207, 220);

    }
    void ExpandPanel()
    {
        for (int i = 0; i < trail.Length; i++)
        {
            trail[i].gameObject.SetActive(true);
        }
        plane.gameObject.SetActive(true);
        spellText.gameObject.SetActive(false);
        img.color = new Color32(65, 63, 63, 199);

    }
}
