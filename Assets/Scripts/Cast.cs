using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Cast : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public List<int> path, spell;
    public bool is_casting { get; private set; } // I start to cast
    private bool is_active; // Can I cast?
    [SerializeField] private Logs log;
    void Start()
    {
        is_active = true;
        is_casting = false;
        path = new List<int>();
        spell = new List<int>();
    }

    public void OnPointerDown(PointerEventData pointerData)
    {
        StartCasting();
    }

    public void OnPointerUp(PointerEventData pointerData)
    {
        EndCasting();
    }

    public void StartCasting()
    {
        is_casting = true;
    }
    public void EndCasting()
    {
        is_casting = false;

        for (int i = 1; i < path.Count; i++)
        {
            spell.Add(path[i] - path[i - 1]);
        }
        //log.SetAndShowLog(Logs.ListToString(path), 4);
        //log.SetAndShowLog(Logs.ListToString(spell), 4);

        spell.Clear();
        path.Clear();
    }
    
}
