using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;

public class Point : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerUpHandler
{

    private int FindId(string s)
    {
        int id = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] > '9' || s[i] < '0') continue;
            id *= 10;
            id += s[i] - '0';
        }
        return id;
    }

    private int id;
    private Cast cast;

    private void Start()
    {
        cast = GetComponentInParent<Cast>();
        id = FindId(transform.parent.name);
    }

    public void OnPointerEnter(PointerEventData pointer_data)
    {

        if (cast.is_casting)
        {
            if (cast.path.Count == 0 || cast.path[cast.path.Count - 1] != id)
                cast.path.Add(id);

        }
    }

    public void OnPointerDown(PointerEventData pointerData)
    {
        cast.StartCasting();
        if (cast.path.Count == 0 || cast.path[cast.path.Count - 1] != id)
            cast.path.Add(id);
    }

    public void OnPointerUp(PointerEventData pointerData)
    {
        cast.EndCasting();
    }

}
