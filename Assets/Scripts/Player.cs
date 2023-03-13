using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IAmAlive
{
    [SerializeField] private Bar HPbar;
    [SerializeField] private Bar MPbar;

    private int maxHP = 100;
    private int hp = 100;
    private int maxMP = 20;
    private int mp = 20;

    void Start()
    {
        RecoverAllHP();
        RecoverAllMP();
        StartCoroutine(RecoveringMP(2, 99999999, 2));
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TakeDamage(5);
        }
        if (Input.GetMouseButtonDown(1))
        {
            HPbar.HideBarValues();
        }
        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            HPbar.UnhideBarValues();
        }
    }

    private void RecoverAllHP()
    {
        hp = maxHP;
        HPbar.ChangeMaxValueTo(maxHP);
        HPbar.ChangeValueTo(hp);
    }
    private void RecoverAllMP()
    {
        mp = maxMP;
        MPbar.ChangeMaxValueTo(maxMP);
        MPbar.ChangeValueTo(mp);
    }

    public void TakeDamage(int d)
    {
        hp -= d;
        if (hp <= 0)
        {
            hp = 0;

        }
        HPbar.ChangeValueTo(hp);
    }
    public void RecoverMP(int m)
    {
        mp += m;
        if (mp <= 0)
        {
            mp = 0;

        }
        if (mp > maxMP)
        {
            mp = maxMP;
        }
        MPbar.ChangeValueTo(mp);
    }

    IEnumerator RecoveringMP(int pc, int c, int s)
    {
        RecoverMP(pc);
        yield return new WaitForSeconds(s);
        if (c > 0)
        {
            StartCoroutine(RecoveringMP(pc, c - 1, s));
        }


    }
    public bool SpendMana(int m)
    {
        if (mp < m) return false;
        RecoverMP(-m);
        return true;
    }

    public int GetMana()
    {
        return mp;
    }
    public int GetHP()
    {
        return hp;
    }
}
