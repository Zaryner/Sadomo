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
    [SerializeField] private GameObject[] spPrefs;
    private List<IAmSpell> spells;
    private IAmAlive opponent;
    private IAmAlive master;
    void Start()
    {
        master = GameObject.Find("Player").GetComponent<IAmAlive>();
        opponent = GameObject.Find("Enemy").GetComponent<IAmAlive>();
        is_active = true;
        is_casting = false;
        path = new List<int>();
        spell = new List<int>();
        spells= new List<IAmSpell>();
        for(int i = 0; i < spPrefs.Length; i++)
        {
            spells.Add(spPrefs[i].GetComponent<IAmSpell>());
        }
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

        ChooseSpell(spell);

        spell.Clear();
        path.Clear();
    }

    private void ChooseSpell(List<int> spell)
    {
        for(int i = 0; i < spells.Count; i++)
        {
            if (ComparePattern(spell, spells[i].GetPattern()))
            {
                if (master.SpendMana(spells[i].GetManaCost()))
                {
                    spells[i].opponent = opponent;
                    spells[i].master = master;
                    Instantiate(spPrefs[i]);

                    spells[i].Cast();
                }
                break;
            }
        }
    }

    private bool ComparePattern(List<int> a, List<int> b)
    {
        if(a.Count != b.Count) return false;
        for(int i=0;i<a.Count;i++)
        {
            if (a[i] != b[i]) return false;
        }
        return true;
    }
    
}
